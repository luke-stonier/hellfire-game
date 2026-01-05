using Nez.Textures;

namespace HellfireGame.Code.Misc;

public class IsometricAnimationSet
{
    public Sprite[] North;
    public Sprite[] NorthEast;
    public Sprite[] East;
    public Sprite[] SouthEast;
    public Sprite[] South;
    public Sprite[] SouthWest;
    public Sprite[] West;
    public Sprite[] NorthWest;
    
    public float framesPerSecond = 1;
    public float moveSpeed = 1;
    
    public IsometricAnimationSet() {}

    public Sprite[] GetAnimation(IsometricDirection direction)
    {
        return direction switch
        {
            IsometricDirection.North => North,
            IsometricDirection.NorthEast => NorthEast,
            IsometricDirection.East => East,
            IsometricDirection.SouthEast => SouthEast,
            IsometricDirection.South => South,
            IsometricDirection.SouthWest => SouthWest,
            IsometricDirection.West => West,
            IsometricDirection.NorthWest => NorthWest,
            _ => SouthEast
        };
    }
}