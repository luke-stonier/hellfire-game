using System;
using Nez.Textures;

namespace HellfireGame.Code.Misc;

public class IsometricAnimationSet
{
    private Sprite[] _north;
    private Sprite[] _northEast;
    private Sprite[] _east;
    private Sprite[] _southEast;
    private Sprite[] _south;
    private Sprite[] _southWest;
    private Sprite[] _west;
    private Sprite[] _northWest;
    
    private float _movementSpeed;
    private int _framesPerSecond;
    
    public float MovementSpeed { get => _movementSpeed; }
    public int FramesPerSecond { get => _framesPerSecond; }

    public IsometricAnimationSet(float movementSpeed, int framesPerSecond)
    {
        _movementSpeed = movementSpeed;
        _framesPerSecond = framesPerSecond;
    }

    public Sprite[] GetAnimation(IsometricDirection direction)
    {
        switch (direction)
        {
            case IsometricDirection.North: return _north;
            case IsometricDirection.NorthEast: return _northEast;
            case IsometricDirection.East: return _east;
            case IsometricDirection.SouthEast: return _southEast;
            case IsometricDirection.South: return _south;
            case IsometricDirection.SouthWest: return _southWest;
            case IsometricDirection.West: return _west;
            case IsometricDirection.NorthWest: return _northWest;
        }

        return _northWest;
    }

    public void SetAnimation(IsometricDirection direction, Sprite[] sprites)
    {
        switch (direction)
        {
            case IsometricDirection.North: _north = sprites; break;
            case IsometricDirection.NorthEast: _northEast = sprites; break;
            case IsometricDirection.East: _east = sprites; break;
            case IsometricDirection.SouthEast: _southEast = sprites; break;
            case IsometricDirection.South: _south =  sprites; break;
            case IsometricDirection.SouthWest: _southWest = sprites; break;
            case IsometricDirection.West: _west = sprites; break;
            case IsometricDirection.NorthWest: _northWest = sprites; break;
        }
    }
}