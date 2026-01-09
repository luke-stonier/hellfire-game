using Microsoft.Xna.Framework;
using System;

public enum IsometricDirection
{
    NorthWest = 0,
    West = 1,
    SouthWest = 2,
    South = 3,
    SouthEast = 4,
    East = 5,
    NorthEast = 6,
    North = 8
}

public static class Vector2Extensions
{
    // convert a vector to an enum value
    public static IsometricDirection ToIsometricDirection(this Vector2 v)
    {
        if (v == Vector2.Zero) return IsometricDirection.North;

        v.Normalize();

        // atan2 gives angle where:
        // (0, -1) = north
        // MonoGame Y+ is down, so invert Y
        float angle = MathF.Atan2(-v.Y, v.X);

        // Convert to [0, 2PI)
        if (angle < 0)
            angle += MathF.Tau;

        // Offset so NorthWest is sector 0
        // Each sector = 45 degrees
        float sectorSize = MathF.Tau / 8f;
        angle += sectorSize / 2f;

        int index = (int)(angle / sectorSize) % 8;

        // Remap clockwise-from-east to your enum order
        // Clockwise starting East:
        // 0:E, 1:NE, 2:N, 3:NW, 4:W, 5:SW, 6:S, 7:SE
        return index switch
        {
            0 => IsometricDirection.East,
            1 => IsometricDirection.NorthEast,
            2 => IsometricDirection.North,
            3 => IsometricDirection.NorthWest,
            4 => IsometricDirection.West,
            5 => IsometricDirection.SouthWest,
            6 => IsometricDirection.South,
            7 => IsometricDirection.SouthEast,
            _ => IsometricDirection.North
        };
    }
}

public static class IsometricDirectionExtensions
{
    // ... tostring
    public static string ToDirectionName(this IsometricDirection direction)
    {
        return direction.ToString().ToLowerInvariant();
    }

    // angled directions are odd number enum values - this is to determine if we need to reduce move speed based on angular direction
    public static bool IsAngledDirection(this IsometricDirection direction)
    {
        return (int)direction % 2 != 0;
    }
}