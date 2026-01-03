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

        var entity = CreateEntity("hello");
        entity.Transform.Position = new Vector2(640, 360);
        entity.AddComponent(new SpriteRenderer(new Sprite(new Texture2D())))
    }
}