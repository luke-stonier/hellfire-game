using System.Collections.Generic;
using HellfireGame.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Nez.Textures;
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