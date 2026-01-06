using HellfireGame.Code.Interfaces;
using HellfireGame.Code.Misc;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace HellfireGame.Code.Components;

public class IsometricMovementController : Component
{
    // required components
    private SpriteAnimator _spriteAnimator;
    //
    private IsometricDirection _lastDirection;
    private IsometricAnimationSet _animationSet;

    public IsometricMovementController(SpriteAnimator spriteAnimator)
    {
        _spriteAnimator =  spriteAnimator;
    }
    
    public void Move(Vector2 direction, MoveType moveType)
    {
        _lastDirection = direction.ToIsometricDirection();
        _spriteAnimator.Play(_lastDirection.ToString());
        Entity.Position += direction * Time.DeltaTime * _animationSet.MovementSpeed;
    }
}