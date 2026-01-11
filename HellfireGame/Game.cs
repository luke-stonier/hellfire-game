using System;
using HellfireGame.Code.Services;
using HellfireGame.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.ImGuiTools;

namespace HellfireGame;

public class Game : Core
{
    public Game() : base(1280, 720, false, "Hellfire")
    {
        IsMouseVisible = false;
    }

    void SetBorderlessFullscreen()
    {
        var dMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
        int dWidth = dMode.Width;
        int dHeight = dMode.Height;
        
        SetWindowSize(dWidth, dHeight);
    }
    
    void SetWindowSize(int width, int height)
    {
        Screen.SetSize(width, height);
    }
    
    protected override void Initialize()
    {
        //
        
        IsometricService.Initialize(Content);
        
        //
        
        base.Initialize();
        
        #if DEBUG
            Window.Position = new Point(-1450, 320);
        #else
            SetBorderlessFullscreen();
        #endif
        
        var imGuiManager = new ImGuiManager();
        imGuiManager.ShowSeperateGameWindow = false;
        imGuiManager.ShowCoreWindow = false;
        RegisterGlobalManager( imGuiManager );
        PauseOnFocusLost = false;
        Scene = new TestScene();
    }
}
