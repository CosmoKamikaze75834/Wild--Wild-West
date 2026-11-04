using UnityEngine;

public class WaveAnnouncementPresenter : MonoBehaviour
{
    [SerializeField] private WaveHandler _waveHandler;
    [SerializeField] private WaveAnnouncementView _waveView;

    private void OnEnable()
    {
        _waveHandler.WaveStarted += StartTextWave;
    }

    private void OnDisable()
    {
        _waveHandler.WaveStarted -= StartTextWave;
    }

    private void StartTextWave(int number)
    {
        int index = number + 1;
        _waveView.Change(index);
        StartCoroutine(_waveView.PlayAnimation());
    }
}