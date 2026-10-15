using UnityEngine;
using UnityEngine.InputSystem;

public class InputScroll : InputActionHandler
{
    public Vector2 ScrollDelta { get; private set; }

    protected override InputAction Action => Input.Player.WeaponScroll;

    protected override void OnAction(InputAction.CallbackContext context) =>
        ScrollDelta = context.ReadValue<Vector2>();

    public Vector2 ConsumeScrollDelta()
    {
        var currentValue = ScrollDelta;

        ScrollDelta = Vector2.zero;

        return currentValue;
    }
}