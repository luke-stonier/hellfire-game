using System;
using Nez;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HellfireGame.Code.Components;

public class InputController : Component, IUpdatable
{
    private MoveIntent _intent;
    private VirtualAxis _moveX;
    private VirtualAxis _moveY;
    
    public override void OnAddedToEntity()
        => _intent = Entity.GetOrCreateComponent<MoveIntent>();
    
    public InputController()
    {
        Start();
    }

    private void Start()
    {
        InitControllerInput();
    }
    
    void IUpdatable.Update()
    {
        // Vector2 move = new Vector2(_moveX.Value, _moveY.Value);
        //
        // if (move.LengthSquared() > 1f)
        //     move.Normalize();
        
        _intent.Direction = new Vector2(_moveX.Value, _moveY.Value);
    }

    private void InitControllerInput()
    {
        // Horizontal movement
        _moveX = new VirtualAxis();
        _moveX.Nodes.Add(new VirtualAxis.KeyboardKeys(
            VirtualInput.OverlapBehavior.TakeNewer,
            Keys.A, Keys.D));

        _moveX.Nodes.Add(new VirtualAxis.GamePadLeftStickX());
        _moveX.Nodes.Add(new VirtualAxis.GamePadDpadLeftRight());

        // Vertical movement
        _moveY = new VirtualAxis();
        _moveY.Nodes.Add(new VirtualAxis.KeyboardKeys(
            VirtualInput.OverlapBehavior.TakeNewer,
            Keys.W, Keys.S));

        // Invert Y for stick (up = -1)
        _moveY.Nodes.Add(new VirtualAxis.GamePadLeftStickY(0));
        _moveY.Nodes.Add(new VirtualAxis.GamePadDpadUpDown());
    }
}