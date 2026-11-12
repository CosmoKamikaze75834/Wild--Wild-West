using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveHandler : MonoBehaviour
{
    [SerializeField] private Wave[] _wave;
    [SerializeField] private Spawner _spawner;
    [SerializeField, Min(1)] private float _bossSpawnDelay = 5f;

    private readonly WaveProgress _progress = new WaveProgress();

    private int _maxWaveDelay = 7;
    private int _minWaveDelay = 4;
    private int _currentWaveIndex;

    private CancellationTokenSource _cancellationTokenSource;

    public event Action AllWavesCompleted;
    public event Action<int> WaveStarted;
    public event Action BossStarted;

    private void OnEnable()
    {
        _cancellationTokenSource = new CancellationTokenSource();

        _spawner.Spawn += _progress.OnEnemySpawned;
        _spawner.EnemyDied += OnEnemyDied; 
        _spawner.BossDied += OnBossDied;
    }

    private void OnDisable()
    {
        _spawner.Spawn -= _progress.OnEnemySpawned;
        _spawner.EnemyDied -= OnEnemyDied;
        _spawner.BossDied -= OnBossDied;

        if (_cancellationTokenSource != null)
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
        }

        _spawner.StopSpawning();
    }

    private void Start()
    {
        _ = ExecuteSafelyAsync(() => StartNextWaveAsync(_cancellationTokenSource.Token));
    }

    private async Task RunWaveAsync()
    {
        await _spawner.StartSpawning(_wave[_currentWaveIndex].EnemyCount, _wave[_currentWaveIndex].EnemySpawnInterval);
        _progress.MarkSpawningCompleted();
        CheckWaveCompletion();
    }

    private void CheckWaveCompletion()
    {
        if (_progress.TryScheduleBoss())
            _ = ExecuteSafelyAsync(() => SpawnBossDelay(_cancellationTokenSource.Token));
    }

    private async Task SpawnBossDelay(CancellationToken token)
    {
        await WaitAsync(_bossSpawnDelay, token);
        BossStarted?.Invoke();
        _spawner.SpawnBoss();
    }

    private void OnBossDied(Enemy enemy)
    {
        _currentWaveIndex++;

        if (_currentWaveIndex >= _wave.Length)
        {
            AllWavesCompleted?.Invoke();
            return;
        }

        _progress.Reset();

        _ = ExecuteSafelyAsync(() => StartNextWaveAsync(_cancellationTokenSource.Token));
    }

    private async Task StartNextWaveAsync(CancellationToken token)
    {
        await WaitAsync(Random.Range(_minWaveDelay, _maxWaveDelay), token);
        WaveStarted?.Invoke(_currentWaveIndex);
        await RunWaveAsync();
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _progress.OnEnemyDied(enemy);
        CheckWaveCompletion();
    }

    private async Task WaitAsync(float delay, CancellationToken token)
    {
        await Task.Delay(TimeSpan.FromSeconds(delay), token);
    }

    private async Task ExecuteSafelyAsync(Func<Task> operation)
    {
        try
        {
            await operation();
        }
        catch (OperationCanceledException)
        {

        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
        }
    }
}