using UnityEngine.InputSystem;

public class InputAim : InputActionHandler
{
    public bool IsAiming { get; private set; }

    protected override InputAction Action => Input.Player.Aim;

    protected override void OnAction(InputAction.CallbackContext context) =>
        IsAiming = context.ReadValueAsButton();
}