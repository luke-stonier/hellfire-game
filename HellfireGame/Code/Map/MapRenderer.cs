using HellfireGame.Code.Services;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace  HellfireGame.Code.Map;

public class MapRenderer
{
    private readonly Scene _scene;
    public MapRenderer(Scene scene)
    {
        _scene = scene;
        
        LoadDemoTemplate();
    }

    private void LoadDemoTemplate()
    {
        var sprite = IsometricService.Load("Assets/Demo/isometric_map");
        var template = new Entity("Demo template");
        template.AddComponent(new SpriteRenderer(sprite));
        template.LocalScale = new Vector2(2f);
        _scene.AddEntity(template);
    }
}
