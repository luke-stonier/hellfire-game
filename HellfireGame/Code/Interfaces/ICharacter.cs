using HellfireGame.Code.Misc;
using Microsoft.Xna.Framework;
using Nez;

public interface ICharacter
{
    IsometricDirection direction { get; }
    IsometricAnimationSet animationSet { get; }   
    
    void Move(Vector2 direction, MoveType moveType);
}