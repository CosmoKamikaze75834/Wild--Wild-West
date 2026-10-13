using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerInputProvider : MonoBehaviour
{
    public PlayerInput PlayerInput { get; private set; }

    private void Awake() =>
        PlayerInput = new PlayerInput();
}