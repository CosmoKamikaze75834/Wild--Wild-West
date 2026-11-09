using UnityEngine.InputSystem;

public class InputAttack : InputActionHandler
{
    public bool IsAttack { get; private set; }

    protected override InputAction Action => Input.Player.Attack;

    protected override void OnAction(InputAction.CallbackContext context) =>
        IsAttack = context.ReadValueAsButton();
}