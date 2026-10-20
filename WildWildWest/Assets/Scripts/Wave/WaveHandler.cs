using System;
using System.Threading.Tasks;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    [SerializeField] private Wave _wave;
    [SerializeField] private Spawner _spawner;

    private int _numberEnemiesSpawned;
    private int _countEnemyDied;

    private bool _spawnEnd;
    private bool _isWaveCompleted;

    private async void Start()
    {
        try
        {
            await LaunchWave();//ждёт пока спавнер закончит создание вргаов
            Debug.Log("Все враги появились");
            _spawnEnd = true;
            CheckWaveCompletion();
        }
        catch (OperationCanceledException)
        {
            Debug.Log("Спавн врагов отменён");
        }
        catch(Exception exception)
        {
            Debug.LogException(exception);
        }
    }

    private void OnEnable()
    {
        _spawner.OnSpawn += OnEnemySpawned;
        _spawner.EnemyDied += OnEnemyDied;
    }
    private void OnDisable()
    {
        _spawner.OnSpawn -= OnEnemySpawned;
        _spawner.EnemyDied -= OnEnemyDied;
    }

    public Task LaunchWave()
    {
        return _spawner.StartSpawning(_wave.EnemyCount, _wave.EnemySpawnInterval);
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        _numberEnemiesSpawned++;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _countEnemyDied++;
        CheckWaveCompletion();
    }

    private void CheckWaveCompletion()
    {
        if (_isWaveCompleted)
            return;

        if (_spawnEnd && _numberEnemiesSpawned == _countEnemyDied)
        {
            Debug.Log("Все обычные враги побеждены!");
            _isWaveCompleted = true;
        }
    }
}