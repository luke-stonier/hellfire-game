using HellfireGame.Code.Services;
using HellfireGame.Scenes;
using Microsoft.Xna.Framework;
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
        //
        
        IsometricService.Initialize(Content);
        
        //
        
        base.Initialize();
        
        //Window.Position = new Point(-1450, 320);
        
        var imGuiManager = new ImGuiManager();
        imGuiManager.ShowSeperateGameWindow = false;
        imGuiManager.ShowCoreWindow = false;
        RegisterGlobalManager( imGuiManager );
        PauseOnFocusLost = false;
        Scene = new TestScene();
    }
}
