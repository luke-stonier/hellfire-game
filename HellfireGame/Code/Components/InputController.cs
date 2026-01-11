using System;
using HellfireGame.Code.Constants;
using HellfireGame.Code.Intents;
using Nez;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HellfireGame.Code.Components;

public class InputController : Component, IUpdatable
{
    // externals
    private MoveIntent _moveIntent;
    private ActionIntent _actionIntent;
    
    // movement axis
    private VirtualAxis _moveX;
    private VirtualAxis _moveY;
    
    // modifiers
    private VirtualButton _runningInput;
    private VirtualButton _crouchingInput;
    
    // actions 
    private VirtualButton _jumping;

    public override void OnAddedToEntity()
    {
        _moveIntent = Entity.GetOrCreateComponent<MoveIntent>();
        _actionIntent = Entity.GetOrCreateComponent<ActionIntent>();
    }

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
        
        _moveIntent.Direction = direction;
        if (_moveIntent.Direction == Vector2.Zero)
        {
            _moveIntent.AnimationToPlay = AnimationName.IDLE;
        }
        else
        {
            // set running (priority) -> crouching, default to walk
            _moveIntent.AnimationToPlay = _runningInput.IsDown ? AnimationName.RUN :
                _crouchingInput.IsDown ? AnimationName.CROUCH : AnimationName.WALK;
        }

        _actionIntent.Jumping = _jumping.IsDown;
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
        
        // Actions
        _jumping = new VirtualButton();
        _jumping.AddKeyboardKey(Keys.Space)
            .AddGamePadButton(0, Buttons.A);
    }
}