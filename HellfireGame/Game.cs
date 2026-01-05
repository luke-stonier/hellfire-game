using HellfireGame.Scenes;
using Nez;
using Nez.ImGuiTools;

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
        //Window.Position = new Point(-1450, 320);
        
        var imGuiManager = new ImGuiManager();
        Core.RegisterGlobalManager( imGuiManager );
        
        Scene = new TestScene();
    }
}
