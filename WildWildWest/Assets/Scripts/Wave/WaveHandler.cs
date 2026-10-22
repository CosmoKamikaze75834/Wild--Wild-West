using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

//управляет последовательностью волн
public class WaveHandler : MonoBehaviour
{
    [SerializeField] private Wave[] _wave;
    [SerializeField] private Spawner _spawner;
    [SerializeField, Min(1)] private float _bossSpawnDelay = 5f;

    private readonly WaveProgress _progress = new WaveProgress();

    private int _maxWaveDelay = 15;
    private int _minWaveDelay = 7;

    private int _currentWaveIndex;

    private CancellationTokenSource _cancellationTokenSource;

    public event Action AllWavesCompleted;

    private void OnEnable()
    {
        _cancellationTokenSource = new CancellationTokenSource();

        _spawner.OnSpawn += _progress.OnEnemySpawned;
        _spawner.EnemyDied += OnEnemyDied;
        _spawner.BossDied += OnBossDied;
    }

    private void OnDisable()
    {
        _spawner.OnSpawn -= _progress.OnEnemySpawned;
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

    private async void Start()
    {
        await ExecuteSafelyAsync(RunWaveAsync);
    }

    //1 - запускает обычных врагов
    private async Task RunWaveAsync()
    {
        await _spawner.StartSpawning(_wave[_currentWaveIndex].EnemyCount, _wave[_currentWaveIndex].EnemySpawnInterval);//запуск волны
        _progress.MarkSpawningCompleted();
        CheckWaveCompletion();
    }

    //2 - все враги созданы и погибли?
    private void CheckWaveCompletion()
    {
        if (_progress.TryScheduleBoss())
            _ = ExecuteSafelyAsync(() => SpawnBossDelay(_cancellationTokenSource.Token));
    }

    //3 - ожидание .. и появление босса
    private async Task SpawnBossDelay(CancellationToken token)
    {
        await WaitAsync(_bossSpawnDelay, token);
        _spawner.SpawnBoss();
    }

    //4 - првоерка следующей волны и сброс состояния
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

    //5 - повторяет цикл пока не закончатся волны
    private async Task StartNextWaveAsync(CancellationToken token)
    {
        await WaitAsync(Random.Range(_minWaveDelay, _maxWaveDelay), token);
        await RunWaveAsync();
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _progress.OnEnemyDied(enemy);
        CheckWaveCompletion();//проверка условия перехода к боссу
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