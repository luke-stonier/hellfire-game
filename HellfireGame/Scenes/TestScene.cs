using Nez;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Nez.Textures;

namespace HellfireGame.Scenes;

public class TestScene : Scene
{
    public override void Initialize()
    {
        base.Initialize();
        ClearColor = Color.Black;

        var entity = CreateEntity("character-prototype");
        entity.Transform.Position = new Vector2(640, 360);
        
        var texture = Content.Load<Texture2D>("Assets/Character/character-prototype");
        var frames = SliceRowSprites(texture, frameWidth: 64, frameHeight: 64, startX: 0, startY: 0, frameCount: 8);

        var idleAnim = new SpriteAnimation(frames, 10);

        // Add animator + play
        var animator = entity.AddComponent(new SpriteAnimator());
        animator.AddAnimation("idle", idleAnim);
        animator.Play("idle");
    }
    
    static Sprite[] SliceRowSprites(Texture2D tex, int frameWidth, int frameHeight, int startX, int startY, int frameCount)
    {
        var sprites = new Sprite[frameCount];

        for (int i = 0; i < frameCount; i++)
        {
            var rect = new Rectangle(startX + i * frameWidth, startY, frameWidth, frameHeight);
            sprites[i] = new Sprite(tex, rect);
        }

        return sprites;
    }
}