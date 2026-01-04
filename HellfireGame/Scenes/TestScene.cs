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
        entity.AddComponent(new SpriteRenderer(texture));
    }
}