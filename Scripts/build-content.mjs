import fs from "fs";
import path from "path";
import { execSync } from "child_process";

// When run from an npm script, cwd is usually repo root. If you run directly from Scripts,
// this keeps it stable by anchoring to the script's folder.
import { fileURLToPath } from "url";
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

// Repo root is parent of Scripts/
const repoRoot = path.resolve(__dirname, "..");

// Your folders
const assetsDir = path.join(repoRoot, "Assets");
const contentDir = path.join(repoRoot, "HellfireGame", "Content");
const mgcbPath = path.join(contentDir, "Content.mgcb");

// MGCB output paths are relative to the mgcb file location.
// We want output in the same Content folder, and intermediates in Content/obj/Content
const outputDir = "."; // = HellfireGame/Content
const intermediateDir = "obj/Content";

const sleep = ms => new Promise(resolve => setTimeout(resolve, ms));

// recursively find files
function walk(dir) {
    const out = [];
    for (const entry of fs.readdirSync(dir, { withFileTypes: true })) {
        const full = path.join(dir, entry.name);
        if (entry.isDirectory()) out.push(...walk(full));
        else out.push(full);
    }
    return out;
}

const pngs = walk(assetsDir).filter(f => f.toLowerCase().endsWith(".png"));

// Ensure Content dir exists
fs.mkdirSync(contentDir, { recursive: true });

// Build mgcb contents
let mgcb = `#----------------------------- Global Properties -----------------------------#

/outputDir:${outputDir}
/intermediateDir:${intermediateDir}
/platform:DesktopGL
/profile:Reach
/compress:False

#-------------------------------- References --------------------------------#

#---------------------------------- Content ---------------------------------#
`;

for (const file of pngs) {
    // Paths in mgcb entries should be relative to the mgcb file's directory
    const relFromMgcb = path
        .relative(path.dirname(mgcbPath), file)
        .replaceAll("\\", "/");

    // This produces asset names like: ../Assets/foo/bar.png -> load with "foo/bar"
    mgcb += `\n#begin ${relFromMgcb}\n`;
    mgcb += `/importer:TextureImporter\n`;
    mgcb += `/processor:TextureProcessor\n`;
    mgcb += `/processorParam:ColorKeyEnabled=False\n`;
    mgcb += `/build:${relFromMgcb}\n`;
    mgcb += `#end ${relFromMgcb}\n`;
}

fs.writeFileSync(mgcbPath, mgcb, "utf8");
console.log(`Wrote ${mgcbPath} with ${pngs.length} textures.`);

// Run MGCB. Requires dotnet-mgcb installed and mgcb on PATH.

// Ensure Content dir exists
fs.mkdirSync(contentDir, { recursive: true });

// Ensure MGCB intermediate folder exists (so it can write obj/Content/.mgcontent)
fs.mkdirSync(path.join(contentDir, ...intermediateDir.split("/")), { recursive: true });

execSync(`mgcb "${mgcbPath}" /rebuild`, { stdio: "inherit" });

await sleep(2000);
