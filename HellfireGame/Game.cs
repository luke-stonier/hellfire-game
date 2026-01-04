using HellfireGame.Scenes;
//using MonoGameReload;
using Nez;

namespace HellfireGame;

public class Game : Core
{
    public Game() : base(1280, 720, false, "Hellfire")
    {
        // hot reload
        /*Reloader.Initialize(
            Content,
            GraphicsDevice,
            Microsoft.Xna.Framework.Content.Pipeline.TargetPlatform.DesktopGL
        );*/
        // end hot reload
        
        IsMouseVisible = true;
        // var imGuiManager = new ImGuiManager();
        // Core.RegisterGlobalManager( imGuiManager );
    }
    
    protected override void Initialize()
    {
        base.Initialize();
        Scene = new TestScene();
    }
}
