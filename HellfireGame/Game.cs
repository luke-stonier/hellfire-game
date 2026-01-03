using HellfireGame.Scenes;
using Microsoft.Xna.Framework;
using Nez;

namespace HellfireGame;

public class Game : Core
{
    public Game() : base(1280, 720, false, "Hellfire")
    {
        IsMouseVisible = true;
    }
    
    protected override void Initialize()
    {
        base.Initialize();
        Scene = new TestScene();
    }
}
