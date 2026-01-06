using System;
using Nez.Sprites;
using Nez.Textures;

namespace HellfireGame.Code.Misc;

public class IsometricAnimationSet
{
    private SpriteAnimation _north;
    private SpriteAnimation _northEast;
    private SpriteAnimation _east;
    private SpriteAnimation _southEast;
    private SpriteAnimation _south;
    private SpriteAnimation _southWest;
    private SpriteAnimation _west;
    private SpriteAnimation _northWest;
    
    private float _movementSpeed;
    private int _framesPerSecond;
    
    public float MovementSpeed { get => _movementSpeed; }
    public int FramesPerSecond { get => _framesPerSecond; }

    public IsometricAnimationSet(float movementSpeed, int framesPerSecond)
    {
        _movementSpeed = movementSpeed;
        _framesPerSecond = framesPerSecond;
    }

    public SpriteAnimation GetAnimation(IsometricDirection direction)
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
        var animation = new SpriteAnimation(sprites, FramesPerSecond);
        switch (direction)
        {
            case IsometricDirection.North: _north = animation; break;
            case IsometricDirection.NorthEast: _northEast = animation; break;
            case IsometricDirection.East: _east = animation; break;
            case IsometricDirection.SouthEast: _southEast = animation; break;
            case IsometricDirection.South: _south =  animation; break;
            case IsometricDirection.SouthWest: _southWest = animation; break;
            case IsometricDirection.West: _west = animation; break;
            case IsometricDirection.NorthWest: _northWest = animation; break;
        }
    }
}