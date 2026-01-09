using System.Collections.Generic;
using System.Linq;
using HellfireGame.Code.Constants;
using Nez.Sprites;
using Nez.Textures;

namespace HellfireGame.Code.Misc;

public class DirectionAnimation
{
    public string AnimationName { get; }
    public IsometricDirection Direction;
    public SpriteAnimation Animation;
    public float MovementSpeed;

    public DirectionAnimation(string animationName, IsometricDirection direction, SpriteAnimation spriteAnimation, float movementSpeed)
    {
        AnimationName = $"{animationName}_{direction.ToDirectionName()}";
        Direction = direction;
        Animation = spriteAnimation;
        MovementSpeed = movementSpeed;
    }
}

public class IsometricAnimationSet
{
    // internals
    private readonly List<DirectionAnimation> _directionAnimations = new List<DirectionAnimation>();
    private float MovementSpeed { get; }
    private int FramesPerSecond { get; }
    
    
    // external
    public AnimationName AnimationName { get; }


    // config

    public IsometricAnimationSet(AnimationName animationName, float movementSpeed, int framesPerSecond)
    {
        AnimationName = animationName;
        MovementSpeed = movementSpeed;
        FramesPerSecond = framesPerSecond;
    }
    
    // public

    public int AnimationCount() => _directionAnimations.Count;
    public List<DirectionAnimation> AllAnimations() => _directionAnimations;

    public DirectionAnimation GetAnimation(IsometricDirection direction)
    {
        var savedAnimation = _directionAnimations.Find(animation => animation.Direction == direction);
        return savedAnimation;
    }

    public void SetAnimation(IsometricDirection direction, Sprite[] sprites)
    {
        var savedAnimation = _directionAnimations.Find(animation => animation.Direction == direction);
        var animation = new SpriteAnimation(sprites, FramesPerSecond);
        if (savedAnimation != null) _directionAnimations.Remove(savedAnimation);
        _directionAnimations.Add(new DirectionAnimation(AnimationName.ToAnimationName(), direction, animation, MovementSpeed));
    }
}

public class LayeredIsometricAnimationSet
{
    private readonly List<IsometricAnimationSet> _isometricAnimationSets = new List<IsometricAnimationSet>();
    
    public void AddIsometricAnimationSet(IsometricAnimationSet animationSet) => _isometricAnimationSets.Add(animationSet);
    public IsometricAnimationSet GetAnimationSet(AnimationName animationName) => _isometricAnimationSets.Find(animation => animation.AnimationName == animationName); 
}