using HellfireGame.Code.Constants;
using Nez.Sprites;

namespace HellfireGame.Code.Components;

public class AnimationController
{
    private readonly SpriteAnimator _spriteAnimator;
    
    private AnimationName _lastAnimationName;
    private IsometricDirection _lastIsometricDirection;

    public AnimationController(SpriteAnimator spriteAnimator)
    {
        _spriteAnimator = spriteAnimator;
    }
    
    public void PlayAnimation(AnimationName animationName, IsometricDirection isometricDirection)
    {
        if (animationName == _lastAnimationName && isometricDirection == _lastIsometricDirection) return; // nothing to update
        _lastAnimationName = animationName;
        _lastIsometricDirection = isometricDirection;
        _spriteAnimator.Play(animationName.ToAnimation(isometricDirection));
    }
}