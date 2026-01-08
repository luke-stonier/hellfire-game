using HellfireGame.Code.Interfaces;
using HellfireGame.Code.Misc;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace HellfireGame.Code.Components;

public class IsometricMovementController : Component, IUpdatable
{
    private MoveIntent _intent;
    
    // required components
    private SpriteAnimator _spriteAnimator;
    //
    private IsometricDirection _lastDirection;
    private IsometricAnimationSet _animationSet;

    public IsometricMovementController(SpriteAnimator spriteAnimator)
    {
        _spriteAnimator =  spriteAnimator;
    }
    
    public override void OnAddedToEntity()
        => _intent = Entity.GetComponent<MoveIntent>();

    void IUpdatable.Update()
    {
        Move(_intent.Direction, MoveType.Walking);
    }
    
    private void Move(Vector2 direction, MoveType moveType)
    {
        if (direction == Vector2.Zero) return;
        _lastDirection = direction.ToIsometricDirection();
        // _spriteAnimator.Play(_lastDirection.ToString());
        var moveSpeed = _animationSet?.MovementSpeed ?? 100;
        Entity.Position += direction * Time.DeltaTime * moveSpeed;
    }
}