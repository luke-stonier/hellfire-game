using Nez;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Nez.Textures;
using Nez.UI;

namespace HellfireGame.Scenes;

public class TestScene : Scene
{
    public override void Initialize()
    {
        base.Initialize();
        ClearColor = Color.Black;

        var entity = CreateEntity("character-prototype");
        entity.Transform.Position = new Vector2(640, 360);
        entity.Transform.Scale = new Vector2(2f);
        
        var texture = Content.Load<Texture2D>("Assets/Character/character-prototype");
        var frames = Sprite.SpritesFromAtlas(texture, 64,64, 0, 12);
        var idleAnim = new SpriteAnimation(frames.ToArray(), 12);

        // Add animator + play
        var animator = entity.AddComponent(new SpriteAnimator());
        animator.AddAnimation("idle", idleAnim);
        animator.Play("idle");
    }
}