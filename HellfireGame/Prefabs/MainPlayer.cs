using System;
using HellfireGame.Code.Constants;
using HellfireGame.Entities;
using Microsoft.Xna.Framework;

public class MainPlayer : Player
{
    public MainPlayer()
    {
        ConfigureAnimations();

        Start();
        Transform.Position = new Vector2(360, 420);
        Transform.Scale = new Vector2(2f);
    }

    private void ConfigureAnimations()
    {
        AddAnimation(AnimationNames.IDLE,"Assets/Character/character-prototype/idle");
        AddAnimation(AnimationNames.WALK,"Assets/Character/character-prototype/walk");
        AddAnimation(AnimationNames.RUN,"Assets/Character/character-prototype/run");
    }
}