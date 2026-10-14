using UnityEngine;
using UnityEngine.InputSystem;

public class InputJump : InputActionHandler
{
    public bool IsJump { get; private set; }

    protected override InputAction Action => Input.Player.Jump;

    protected override void OnAction(InputAction.CallbackContext context) =>
        IsJump = context.ReadValueAsButton();
}