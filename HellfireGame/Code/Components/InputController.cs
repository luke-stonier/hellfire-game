using System;
using HellfireGame.Code.Constants;
using Nez;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HellfireGame.Code.Components;

public class InputController : Component, IUpdatable
{
    private MoveIntent _intent;
    private VirtualAxis _moveX;
    private VirtualAxis _moveY;
    
    // modifiers
    private VirtualButton _runningInput;
    private VirtualButton _crouchingInput;
    
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
        var direction = new Vector2(_moveX.Value, _moveY.Value);

        if (direction.LengthSquared() > 1f)
            direction.Normalize();
        
        _intent.Direction = direction;
        if (_intent.Direction == Vector2.Zero)
        {
            _intent.AnimationToPlay = AnimationName.IDLE;
        }
        else
        {
            // set running (priority) -> crouching, default to walk
            _intent.AnimationToPlay = _runningInput.IsDown ? AnimationName.RUN :
                _crouchingInput.IsDown ? AnimationName.CROUCH : AnimationName.WALK;
        }
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

        // Movement Modifiers
        _runningInput = new VirtualButton();
        _runningInput.AddKeyboardKey(Keys.LeftShift)
            .AddKeyboardKey(Keys.RightShift)
            .AddGamePadButton(0, Buttons.LeftStick);
        
        _crouchingInput = new VirtualButton();
        _crouchingInput.AddKeyboardKey(Keys.LeftControl)
            .AddKeyboardKey(Keys.RightControl)
            .AddGamePadButton(0, Buttons.RightStick);
    }
}