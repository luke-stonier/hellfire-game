using Nez.Textures;

namespace HellfireGame.Code.Misc;

public class IsometricAnimationSet
{
    private Sprite[] _North;
    private Sprite[] _NorthEast;
    private Sprite[] _East;
    private Sprite[] _SouthEast;
    private Sprite[] _South;
    private Sprite[] _SouthWest;
    private Sprite[] _West;
    private Sprite[] _NorthWest;
    
    private float _framesPerSecond = 1;
    private float _movementSpeed = 1;
    
    public float MovementSpeed { get => _movementSpeed; }
    public float FramesPerSecond { get => _framesPerSecond; }

    public Sprite[] GetAnimation(IsometricDirection direction)
    {
        switch (direction)
        {
            case IsometricDirection.North: return _North;
            case IsometricDirection.NorthEast: return _NorthEast;
            case IsometricDirection.East: return _East;
            case IsometricDirection.SouthEast: return _SouthEast;
            case IsometricDirection.South: return _South;
            case IsometricDirection.SouthWest: return _SouthWest;
            case IsometricDirection.West: return _West;
            case IsometricDirection.NorthWest: return _NorthWest;
            default: return _NorthWest;
        }
    }
}