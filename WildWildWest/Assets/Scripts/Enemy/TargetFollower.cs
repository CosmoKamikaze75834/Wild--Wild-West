using System;
using UnityEngine;

//следует за игроком
public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private EnemyNavigation _navigation;

    private bool _isArrived;//дошёл до игрока

    public event Action Arrived;

    public void Follow()
    {
        if (_target == null)
            return;

        if (_isArrived)
            return;

        if (_navigation.PathPending)
            return;

        if (_navigation.RemainingDistance <= _navigation.StoppingDistance)
        {
            _isArrived = true;
            Arrived?.Invoke();
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
        _isArrived = false;
    }

    public void Stop() =>
        _navigation.Stop();

    public void Resume() =>
        _navigation.Resume();
}