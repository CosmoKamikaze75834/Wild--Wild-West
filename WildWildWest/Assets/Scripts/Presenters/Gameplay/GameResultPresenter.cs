using UnityEngine;

public class GameResultPresenter : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private WaveHandler _waveHandler;
    [SerializeField] private GameplayPause _playPause;

    [SerializeField] private GameResultWindow _windowDefeat;
    [SerializeField] private GameResultWindow _windowVictory;

    private void OnEnable()
    {
        _health.Died += _windowDefeat.Open;
        _waveHandler.AllWavesCompleted += OpenVictory;
    }

    private void OnDisable()
    {
        _health.Died -= _windowDefeat.Open;
        _waveHandler.AllWavesCompleted -= OpenVictory;
    }

    private void OpenVictory()
    {
        _playPause.EstablishPause();
        _windowVictory.Open();
    }
}