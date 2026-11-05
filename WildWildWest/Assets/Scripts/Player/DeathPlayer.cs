using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private GameplayPause _gameplayPause;

    private void OnEnable()
    {
        _health.OnDied += _gameplayPause.EstablishPause;
    }

    private void OnDisable()
    {
        _health.OnDied -= _gameplayPause.EstablishPause;
    }
}