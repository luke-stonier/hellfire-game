using HellfireGame.Code.Constants;
using HellfireGame.Code.Misc;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace HellfireGame.Code.Components;

public class IsometricMovementController : Component, IUpdatable
{
    private MoveIntent _intent;
    private readonly SpriteAnimator _spriteAnimator;
    private LayeredIsometricAnimationSet _isometricAnimationSet;
    
    private string _lastAnimationName;
    private IsometricDirection _lastDirection = IsometricDirection.South;

    public IsometricMovementController(SpriteAnimator spriteAnimator)
    {
        _spriteAnimator =  spriteAnimator;
    }
    
    public IsometricMovementController(SpriteAnimator spriteAnimator, LayeredIsometricAnimationSet isometricAnimationSet)
    {
        _spriteAnimator =  spriteAnimator;
        _isometricAnimationSet = isometricAnimationSet;
    }

    public IsometricMovementController AddAnimationSet(LayeredIsometricAnimationSet animationSet)
    {
        _isometricAnimationSet = animationSet;
        return this;
    }
    
    public override void OnAddedToEntity()
        => _intent = Entity.GetComponent<MoveIntent>();

    void IUpdatable.Update()
    {
        if (_intent == null) return;
        
        // update last direction (facing) if we are moving and it's not in the same direction as last frame
        var direction = _intent.Direction.ToIsometricDirection();
        if (_intent.Direction != Vector2.Zero && _lastDirection != direction) _lastDirection = direction;

        var animation = _isometricAnimationSet.GetAnimationSet(_intent.AnimationToPlay)?.GetAnimation(_lastDirection);
        if (animation == null) return;
        if (_lastAnimationName != animation.AnimationName) // update animation if it's not the same as last played
        {
            _lastAnimationName = animation.AnimationName;
            _spriteAnimator.Play(animation.AnimationName);
        }

        Move(_intent.Direction, animation.MovementSpeed);
    }
    
    private void Move(Vector2 direction, float speed)
    {
        if (direction == Vector2.Zero) return;
        Entity.Position += direction * Time.DeltaTime * speed;
    }
}