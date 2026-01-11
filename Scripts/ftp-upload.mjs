import { Client } from "basic-ftp"
import fs from "node:fs"
import fsp from "node:fs/promises"
import path from "node:path"
import process from "node:process"

// ---------- tiny color helpers (no deps) ----------
const c = {
    green: (s) => `\x1b[32m${s}\x1b[0m`,
    red: (s) => `\x1b[31m${s}\x1b[0m`,
    cyan: (s) => `\x1b[36m${s}\x1b[0m`,
    dim: (s) => `\x1b[2m${s}\x1b[0m`,
}

// ---------- config ----------
const cfgPath = process.argv[2]
if (!cfgPath) {
    console.error("Usage: node ftp-upload.mjs ./ftp-package.json")
    process.exit(1)
}

// Strip UTF-8 BOM if present
const raw = fs.readFileSync(cfgPath, "utf8").replace(/^\uFEFF/, "")
const cfg = JSON.parse(raw)

const localRoot = path.resolve(cfg.projectDir)
const remoteRoot = cfg.outputDir.replace(/\/+$/, "") // trim trailing /

if (!fs.existsSync(localRoot)) {
    console.error(c.red(`Local projectDir does not exist: ${localRoot}`))
    process.exit(1)
}

function toPosix(p) {
    return p.split(path.sep).join("/")
}

async function* walkFiles(dir) {
    const entries = await fsp.readdir(dir, { withFileTypes: true })
    for (const ent of entries) {
        const full = path.join(dir, ent.name)
        if (ent.isDirectory()) {
            yield* walkFiles(full)
        } else if (ent.isFile()) {
            yield full
        }
    }
}

async function main() {
    console.log(c.dim(`Local : ${localRoot}`))
    console.log(c.dim(`Remote: ${remoteRoot}`))

    const client = new Client()
    client.ftp.verbose = false // <-- no EPSV/CWD spam

    let ok = 0
    let fail = 0

    try {
        await client.access({
            host: cfg.host,
            user: cfg.user,
            password: cfg.pass,
            secure: true, // explicit FTPS
            secureOptions: {
                rejectUnauthorized: false, // LAN/self-signed (remove later if you trust cert properly)
            },
        })

        // Ensure base dir exists and set it as our "home" for uploads
        await client.ensureDir(remoteRoot)
        await client.cd(remoteRoot)

        for await (const file of walkFiles(localRoot)) {
            const rel = path.relative(localRoot, file)
            const relPosix = toPosix(rel)

            // Create/ensure target directory (relative to remoteRoot)
            const remoteDirRel = path.posix.dirname(relPosix)
            const remoteName = path.posix.basename(relPosix)

            const size = (await fsp.stat(file)).size

            // Only log files
            process.stdout.write(
                `${c.cyan(relPosix)} ${c.dim(`(${(size / (1024 * 1024)).toFixed(2)} MB)`)} ... `
            )

            try {
                // ensureDir() changes CWD to that dir; so use relative dirs from remoteRoot
                if (remoteDirRel !== "." && remoteDirRel !== "/") {
                    await client.ensureDir(remoteDirRel)
                }
                await client.uploadFrom(file, remoteName)

                // reset back to base so next ensureDir is relative to remoteRoot
                await client.cd(remoteRoot)

                console.log(c.green("OK"))
                ok++
            } catch (e) {
                console.log(c.red("FAIL"))
                console.error(c.red(`  ${e?.message ?? e}`))
                fail++

                // best effort: return to base to keep subsequent uploads sane
                try { await client.cd(remoteRoot) } catch {}
            }
        }
    } finally {
        client.close()
    }

    console.log("")
    console.log(c.green(`Uploaded: ${ok}`) + (fail ? `  ${c.red(`Failed: ${fail}`)}` : ""))
    if (fail) process.exit(1)
}

main().catch((e) => {
    console.error(c.red(e?.stack ?? String(e)))
    process.exit(1)
})
