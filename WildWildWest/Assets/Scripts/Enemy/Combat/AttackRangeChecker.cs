using System;
using UnityEngine;

public class AttackRangeChecker : MonoBehaviour
{
    private bool _isTargetInRange;

    public bool IsTargetInRange => _isTargetInRange;

    public event Action TargetEnteredRange;
    public event Action TargetExitedRange;

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayer(other))
        {
            _isTargetInRange = true;
            TargetEnteredRange?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsPlayer(other))
        {
            _isTargetInRange = false;
            TargetExitedRange?.Invoke();
        }
    }

    private void OnDisable()
    {
        _isTargetInRange = false;
    }

    private bool IsPlayer(Collider other)
    {
        return other.GetComponentInChildren<Player>();
    }
}