using System;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class EnemyPool
{
    private readonly ObjectPool<Enemy> _pool;

    public event Action<Enemy> Died;

    public EnemyPool(Enemy prefab, DiContainer container, int capacity, int maxSize)
    {
        _pool = new ObjectPool<Enemy>(
            createFunc: () => container.InstantiatePrefabForComponent<Enemy>(prefab),
            actionOnGet: null,
            actionOnRelease: enemy => enemy.gameObject.SetActive(false),
            actionOnDestroy: enemy => UnityEngine.Object.Destroy(enemy.gameObject),
            collectionCheck: true,
            defaultCapacity: capacity,
            maxSize: maxSize);
    }

    public Enemy Get()
    {
        Enemy enemy = _pool.Get();
        enemy.Died += OnEnemyDied;

        return enemy;
    }

    public void Release(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        _pool.Release(enemy);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        Release(enemy);
        Died?.Invoke(enemy);
    }
}