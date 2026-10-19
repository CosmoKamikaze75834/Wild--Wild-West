using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyNavigation _navigation;
    [SerializeField] private Health _health;

    public event Action<Enemy> Died;

    private void OnEnable()
    {
        _health.OnDied += NotifyDeath;
    }

    private void OnDisable()
    {
        _health.OnDied -= NotifyDeath;
    }

    //успешно ли переместился враг в точку спавна?
    public bool SpawnAt(Vector3 position)
    {
        if(!_navigation.Warp(position))
            return false;

        _health.Reset();
        _navigation.ResetPath();

        transform.rotation = Quaternion.identity;
        return true;
    }

    private void NotifyDeath()
    {
        Died?.Invoke(this);
    }
}