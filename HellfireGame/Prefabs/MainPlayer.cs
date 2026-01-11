using HellfireGame.Code.Constants;
using HellfireGame.Entities;
using Microsoft.Xna.Framework;

public class MainPlayer : Character
{
    public MainPlayer()
    {
        ConfigureAnimations();

        Awake();

        Start();
        Transform.Position = new Vector2(360, 420);
        Transform.Scale = new Vector2(2f);
    }

    private void ConfigureAnimations()
    {
        AddAnimation(AnimationName.IDLE,"Assets/Character/character-prototype/idle");
        AddAnimation(AnimationName.WALK,"Assets/Character/character-prototype/walk", 8, 125);
        AddAnimation(AnimationName.RUN,"Assets/Character/character-prototype/run", 8, 175);
    }
}