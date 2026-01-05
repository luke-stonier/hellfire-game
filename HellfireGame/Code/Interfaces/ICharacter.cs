using HellfireGame.Code.Misc;
using Microsoft.Xna.Framework;

public interface ICharacter
{
    Vector2 Position { get; set; }
    IsometricDirection direction { get; }
    IsometricAnimationSet animationSet { get; }   
    
    void Move(Vector2 direction, MoveType moveType);
}