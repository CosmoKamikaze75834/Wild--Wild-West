using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Enemy _bossPrefab;
    [SerializeField] private Transform[] _pointsSpawn;

    [SerializeField] private int _poolCapacityEnemy = 5;
    [SerializeField] private int _poolMaxSizeEnemy = 5;

    [SerializeField] private int _poolCapacityBoss = 1;
    [SerializeField] private int _poolMaxSizeBoss = 1;

    private EnemyPool _enemyPool;
    private EnemyPool _bossPool;

    private DiContainer _container;

    private CancellationTokenSource _cancellationTokenSource;
    private Task _spawnTask;

    public event Action<Enemy> Spawn;
    public event Action<Enemy> EnemyDied;
    public event Action<Enemy> BossDied;

    private void Awake()
    {
        _enemyPool = new EnemyPool(_enemyPrefab, _container, _poolCapacityEnemy, _poolMaxSizeEnemy);
        _bossPool = new EnemyPool(_bossPrefab, _container, _poolCapacityBoss, _poolMaxSizeBoss);

        _enemyPool.EnemyDied += OnEnemyDied;
        _bossPool.EnemyDied += OnBossDied;
    }

    public async Task StartSpawning(int enemyCount, float enemySpawnInterval)
    {
        if (_spawnTask != null && !_spawnTask.IsCompleted)
            throw new InvalidOperationException("Спавн уже выполняется");

        _cancellationTokenSource = new CancellationTokenSource();
        CancellationTokenSource source = _cancellationTokenSource;

        try
        {
            _spawnTask = SpawnEnemiesAsync(enemyCount, enemySpawnInterval, source.Token);
            await _spawnTask;
        }
        finally
        {
            source.Dispose();
            _cancellationTokenSource = null;
        }
    }

    public void StopSpawning()
    {
        _cancellationTokenSource?.Cancel();
    }

    public void SpawnBoss()
    {
        TrySpawn(_bossPool, out _);
    }

    private async Task SpawnEnemiesAsync(int enemyCount, float enemySpawnInterval, CancellationToken cancellationToken)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (TrySpawn(_enemyPool, out Enemy enemy))
                Spawn?.Invoke(enemy);

            if (i < enemyCount - 1)
                await Task.Delay(TimeSpan.FromSeconds(enemySpawnInterval), cancellationToken);
        }
    }

    private bool TrySpawn(EnemyPool pool, out Enemy enemy)
    {
        enemy = pool.Get();
        enemy.gameObject.SetActive(true);

        if (PrepareObject(enemy))
            return true;

        pool.Release(enemy);
        enemy = null;

        return false;
    }

    private bool PrepareObject(Enemy enemy)
    {
        int randomPoint = UnityEngine.Random.Range(0, _pointsSpawn.Length);
        Vector3 position = _pointsSpawn[randomPoint].position;

        return enemy.SpawnAt(position);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        EnemyDied?.Invoke(enemy);
    }

    private void OnBossDied(Enemy boss)
    {
        BossDied?.Invoke(boss);
    }


    private void OnDestroy()
    {
        StopSpawning();

        if (_enemyPool != null)
            _enemyPool.EnemyDied -= OnEnemyDied;

        if (_bossPool != null)
            _bossPool.EnemyDied -= OnBossDied;
    }

    [Inject]
    private void Construct(DiContainer container)
    {
        _container = container;
    }
}