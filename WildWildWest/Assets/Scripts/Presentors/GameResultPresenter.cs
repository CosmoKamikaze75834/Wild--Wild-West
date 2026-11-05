using UnityEngine;

public class GameResultPresenter : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private WindowDefeat _windowDefeat;

    [SerializeField] private WaveHandler _waveHandler;
    [SerializeField] private WindowVictory _windowVictory;

    [SerializeField] private GameplayPause _playPause;

    private void OnEnable()
    {
        _health.OnDied += _windowDefeat.Open;
        _waveHandler.AllWavesCompleted += OpenVictory;
    }

    private void OnDisable()
    {
        _health.OnDied -= _windowDefeat.Open;
        _waveHandler.AllWavesCompleted -= OpenVictory;
    }

    private void OpenVictory()
    {
        _playPause.EstablishPause();
        _windowVictory.Open();
    }
}