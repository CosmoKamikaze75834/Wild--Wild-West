using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;

    [SerializeField] private Transform[] _pointsSpawn;

    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<Enemy> _pool;

    public event Action<Enemy> OnSpawn;//враг появился

    public event Action<Enemy> EnemyDied;
    public event Action<Enemy> BossDied;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
        createFunc: () =>
        {
            Enemy enemy = Instantiate(_prefab);
            return enemy;
        },
        actionOnGet: (null),
        actionOnRelease: (enemy) => enemy.gameObject.SetActive(false),
        actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _poolMaxSize);
    }

    public void StartSpawning(int enemyCount, float enemySpawnInterval)
    {
        StartCoroutine(SpawnEnemies(enemyCount, enemySpawnInterval));
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

    public IEnumerator SpawnEnemies(int enemyCount, float enemySpawnInterval)
    {
        WaitForSeconds wait = new WaitForSeconds(enemySpawnInterval);

        for (int i = 0; i < enemyCount; i++)
        {
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
                yield return wait;
        }
    }
}