using System.Collections.Generic;
using HellfireGame.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Nez.Textures;
using Scene = Nez.Scene;

namespace HellfireGame.Scenes;

public class TestScene : Scene
{
    public override void Initialize()
    {
        base.Initialize();
        ClearColor = Color.Black;

        // var entity = CreateEntity("character-prototype");
        // entity.Transform.Position = new Vector2(640, 360);
        // entity.Transform.Scale = new Vector2(2f);
        //
        // var allFrames = new List<Sprite>();
        // var animations = new List<string> {
        //     "Assets/Character/character-prototype/idle",
        //     "Assets/Character/character-prototype/run",
        //     "Assets/Character/character-prototype/walk",
        // };
        //
        // animations.ForEach((string animation) =>
        // {
        //     var idleTexture = Content.Load<Texture2D>(animation);
        //     allFrames.AddRange(Sprite.SpritesFromAtlas(idleTexture, 64, 64, 0, 12 * 8));
        // });
        //
        // var animation = new SpriteAnimation(allFrames.ToArray(), 12);
        // var animator = entity.AddComponent(new SpriteAnimator());
        // animator.AddAnimation("idle", animation);
        // animator.Play("idle");
        
        var player = new Player(new Vector2(640, 360), new Vector2(2), 0);
        AddEntity(player);
    }
}