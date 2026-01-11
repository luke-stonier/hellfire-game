namespace HellfireGame.Code.Constants;

public enum AnimationName
{
    IDLE,
    WALK,
    RUN,
    CROUCH
}

public static class AnimationNameExtensions
{
    public static string ToAnimationName(this AnimationName animationName)
    {
        return animationName.ToString().ToLowerInvariant();
    }

    public static string ToAnimation(this AnimationName animationName, IsometricDirection isometricDirection)
    {
        return animationName.ToAnimationName() + "_" + isometricDirection.ToDirectionName();
    }
}