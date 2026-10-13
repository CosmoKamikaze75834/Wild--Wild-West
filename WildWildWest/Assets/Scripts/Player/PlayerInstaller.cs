using UnityEngine;

public class PlayerInstaller : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private InputSystem _inputSystem;

    private void Awake()
    {
        _movement.Initialize(_inputSystem);
    }
}