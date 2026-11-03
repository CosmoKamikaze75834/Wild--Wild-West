using UnityEngine;
using Zenject;

public class DeathPlayer : MonoBehaviour
{
    private const float TimePlay = 0;

    [SerializeField] private Health _health;

    private PlayerInputHandler _inputHandler;

    private void OnEnable()
    {
        _health.OnDied += EstablishPause;
    }

    private void OnDisable()
    {
        _health.OnDied -= EstablishPause;
    }

    private void EstablishPause()
    {
        _inputHandler.DisablePlayerInput();
        Time.timeScale = TimePlay;
    }

    [Inject]
    private void Construct(PlayerInputHandler playerInput)
    {
        _inputHandler = playerInput;
    }
}