using UnityEngine;

public class WaveAnnouncementPresenter : MonoBehaviour
{
    [SerializeField] private WaveHandler _waveHandler;
    [SerializeField] private GameAnnouncementView _waveView;

    private void OnEnable()
    {
        _waveHandler.WaveStarted += StartTextWave;
        _waveHandler.BossStarted += StartTextBoss;
    }

    private void OnDisable()
    {
        _waveHandler.WaveStarted -= StartTextWave;
        _waveHandler.BossStarted -= StartTextBoss;
    }

    private void StartTextWave(int number)
    {
        int index = number + 1;
        _waveView.ChangeTextWave(index);
        StartCoroutine(_waveView.PlayAnimation());
    }

    private void StartTextBoss()
    {
        _waveView.ChangeTextBoss();
        StartCoroutine(_waveView.PlayAnimation());
    }
}