using HellfireGame.Scenes;
using Microsoft.Xna.Framework;
using Nez;

namespace HellfireGame;

public class Game : Core
{
    public Game() : base(1280, 720, false, "Hellfire")
    {
        IsMouseVisible = true;
        // var imGuiManager = new ImGuiManager();
        // Core.RegisterGlobalManager( imGuiManager );
    }
    
    protected override void Initialize()
    {
        base.Initialize();
        Window.Position = new Point(-1450, 320);
        Scene = new TestScene();
    }
}
