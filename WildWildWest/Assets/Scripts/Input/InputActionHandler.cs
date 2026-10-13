using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InputActionHandler : MonoBehaviour
{
    [SerializeField] protected PlayerInputProvider _inputProvider;

    protected abstract InputAction Action { get; }

    private void OnEnable()
    {
        Action.Enable();

        Action.performed += OnAction;
        Action.canceled += OnAction;

    }

    private void OnDisable()
    {
        Action.Disable();

        Action.performed -= OnAction;
        Action.canceled -= OnAction;
    }

    protected abstract void OnAction(InputAction.CallbackContext context);
}