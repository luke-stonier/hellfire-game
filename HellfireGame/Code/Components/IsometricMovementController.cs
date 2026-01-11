using System;
using HellfireGame.Code.Constants;
using HellfireGame.Code.Intents;
using HellfireGame.Code.Misc;
using Microsoft.Xna.Framework;
using Nez;

namespace HellfireGame.Code.Components;

public class IsometricMovementController : Component, IUpdatable
{
    // intent
    private MoveIntent _intent;
    private ActionIntent _actionIntent;
    
    private readonly AnimationController _animationController;
    private LayeredIsometricAnimationSet _isometricAnimationSet;
    private IsometricDirection _lastDirection = IsometricDirection.South;

    public IsometricMovementController(AnimationController animationController)
    {
        _animationController = animationController;
    }
    
    public IsometricMovementController(AnimationController animationController, LayeredIsometricAnimationSet isometricAnimationSet)
    {
        _animationController = animationController;
        _isometricAnimationSet = isometricAnimationSet;
    }

    public IsometricMovementController AddAnimationSet(LayeredIsometricAnimationSet animationSet)
    {
        _isometricAnimationSet = animationSet;
        return this;
    }

    public override void OnAddedToEntity()
    {
        _intent = Entity.GetComponent<MoveIntent>();
        _actionIntent = Entity.GetComponent<ActionIntent>();
    }

    void IUpdatable.Update()
    {
        if (_intent == null) throw new Exception("[IsometricMovementController] No MoveIntent component attached entity");
        
        // update last direction (facing) if we are moving, and it's not in the same direction as last frame
        var direction = _intent.Direction.ToIsometricDirection();
        if (_intent.Direction != Vector2.Zero && _lastDirection != direction) _lastDirection = direction;

        var animation = _isometricAnimationSet.GetAnimationSet(_intent.AnimationToPlay)?.GetAnimation(_lastDirection);
        if (animation == null) return; // gets the speed
        _animationController.PlayAnimation(_intent.AnimationToPlay, _lastDirection);
        
        if (_actionIntent.Jumping) _animationController.PlayAnimation(AnimationName.RUN, IsometricDirection.South);

        Move(_intent.Direction, animation.MovementSpeed);
    }
    
    private void Move(Vector2 direction, float speed)
    {
        if (direction == Vector2.Zero) return;
        Entity.Position += direction * Time.DeltaTime * speed;
    }
}