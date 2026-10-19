using System;
using UnityEngine;

public class AttackRangeChecker : MonoBehaviour
{
    private bool _isTargetInRange;

    public bool IsTargetInRange => _isTargetInRange;

    public event Action OnTargetEnteredRange;
    public event Action OnTargetExitedRange;

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayer(other))
        {
            _isTargetInRange = true;
            OnTargetEnteredRange?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsPlayer(other))
        {
            _isTargetInRange = false;
            OnTargetExitedRange?.Invoke();
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