using Microsoft.Xna.Framework;
using Scene = Nez.Scene;

namespace HellfireGame.Scenes;

public class TestScene : Scene
{
    public override void Initialize()
    {
        base.Initialize();
        ClearColor = Color.Black;
        
        var player = new MainPlayer();
        AddEntity(player);
    }
}