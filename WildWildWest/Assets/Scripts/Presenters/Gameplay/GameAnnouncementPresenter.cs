using UnityEngine;

public class GameAnnouncementPresenter : MonoBehaviour
{
    private const int WaveNumberOffset = 1;

    [SerializeField] private WaveHandler _waveHandler;
    [SerializeField] private GameAnnouncementView _announcementView;

    private void OnEnable()
    {
        _waveHandler.WaveStarted += HandleWaveStarted;
        _waveHandler.BossStarted += HandleBossStarted;
    }

    private void OnDisable()
    {
        _waveHandler.WaveStarted -= HandleWaveStarted;
        _waveHandler.BossStarted -= HandleBossStarted;
    }

    private void HandleWaveStarted(int number)
    {
        int waveNumber = number + WaveNumberOffset;
        _announcementView.ChangeTextWave(waveNumber);
        StartCoroutine(_announcementView.PlayAnimation());
    }

    private void HandleBossStarted()
    {
        _announcementView.ChangeTextBoss();
        StartCoroutine(_announcementView.PlayAnimation());
    }
}