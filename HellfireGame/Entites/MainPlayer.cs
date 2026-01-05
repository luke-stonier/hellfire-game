using HellfireGame.Code.Misc;
using Microsoft.Xna.Framework;

namespace HellfireGame.Entities;

public class MainPlayer : ICharacter
{
    public Vector2 Position { get; set; }
    public IsometricDirection direction { get; }
    public IsometricAnimationSet animationSet { get; }
    public void Move(Vector2 direction, MoveType moveType)
    {
        throw new System.NotImplementedException();
    }
}