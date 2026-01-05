using HellfireGame.Code.Misc;
using Microsoft.Xna.Framework;
using Nez;

public class IsometricMovementController : Component, ICharacter
{
    
    public IsometricDirection direction { get; }
    public IsometricAnimationSet animationSet { get; }
    
    public void Move(Vector2 direction, MoveType moveType)
    {
        throw new System.NotImplementedException();
    }
}