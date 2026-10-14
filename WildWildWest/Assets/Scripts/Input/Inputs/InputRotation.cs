using UnityEngine;
using UnityEngine.InputSystem;

public class InputRotation : InputActionHandler
{
    public Vector2 MouseRotation { get; private set; }

    protected override InputAction Action => Input.Player.Look;

    protected override void OnAction(InputAction.CallbackContext context) =>
        MouseRotation = context.ReadValue<Vector2>();
}