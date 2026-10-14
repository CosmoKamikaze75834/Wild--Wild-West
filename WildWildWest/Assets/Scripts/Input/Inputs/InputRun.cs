using UnityEngine;
using UnityEngine.InputSystem;

public class InputRun : InputActionHandler
{
    public bool IsRunning { get; private set; }

    protected override InputAction Action => Input.Player.Run;

    protected override void OnAction(InputAction.CallbackContext context) =>
        IsRunning = context.ReadValueAsButton();
}