using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform[] _pointsSpawn;

    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<Enemy> _pool;

    private DiContainer _container;

    private CancellationTokenSource _cancellationTokenSource;
    private Task _spawnTask;

    public event Action<Enemy> OnSpawn;//враг появился

    public event Action<Enemy> EnemyDied;
    public event Action<Enemy> BossDied;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
        createFunc: () =>
        {
            Enemy enemy = _container.InstantiatePrefabForComponent<Enemy>(_prefab);
            //enemy.gameObject.SetActive(false);
            return enemy;
        },
        actionOnGet: (null),
        actionOnRelease: (enemy) => enemy.gameObject.SetActive(false),
        actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _poolMaxSize);
    }

    public async Task StartSpawning(int enemyCount, float enemySpawnInterval)
    {                            //задача уже завершила выполнение?
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
            _cancellationTokenSource = null;
            source.Dispose();
        }
    }

    //метод, через который другие классы смогут остановить спавн.
    public void StopSpawning()
    {
        _cancellationTokenSource?.Cancel();
    }

    private bool PrepareObject(Enemy enemy)
    {
        var randomPoint = Random.Range(0, _pointsSpawn.Length);
        var position = _pointsSpawn[randomPoint].position;

        return enemy.SpawnAt(position);
    }

    //возвращение объекта в пул
    private void ReturnEnemyPool(Enemy enemy)
    {
        enemy.Died -= ReturnEnemyPool;
        _pool.Release(enemy);
        EnemyDied?.Invoke(enemy);
    }

    [Inject]
    private void Construct(DiContainer container)
    {
        _container = container;
    }

    private async Task SpawnEnemiesAsync(int enemyCount, float enemySpawnInterval, CancellationToken cancellationToken)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();//явно проверяем токен

            Enemy enemy = _pool.Get();

            enemy.Died += ReturnEnemyPool;
            enemy.gameObject.SetActive(true);

            if (PrepareObject(enemy))
                OnSpawn?.Invoke(enemy);
            else
            {
                enemy.Died -= ReturnEnemyPool;
                _pool.Release(enemy);
            }

            if (i < enemyCount - 1)
                await Task.Delay(TimeSpan.FromSeconds(enemySpawnInterval), cancellationToken);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Spawner уничтожается. Отменяем спавн.");
        StopSpawning();
    }
}