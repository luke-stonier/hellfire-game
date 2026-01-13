using HellfireGame.Code.Components;
using HellfireGame.Code.Map;
using Microsoft.Xna.Framework;
using Nez;
using Scene = Nez.Scene;

namespace HellfireGame.Scenes;

public class TestScene : Scene
{
    public override void Initialize()
    {
        base.Initialize();
        ClearColor = Color.WhiteSmoke;

        var mapRenderer = new MapRenderer(this);
        
        
        var player = new MainPlayer();
        AddEntity(player);

        Camera.AddComponent(
            new SoftFollowCamera(
                player,
                SoftFollowCameraDefaults.MIN_DISTANCE,
                SoftFollowCameraDefaults.MAX_DISTANCE,
                SoftFollowCameraDefaults.FOLLOW_SPEED
            )
        );
    }
}