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
            Debug.Log("Игрок в радиусе атаки");
            _isTargetInRange = true;
            OnTargetEnteredRange?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsPlayer(other))
        {
            Debug.Log("Игрок вышел из радиуса атаки");
            _isTargetInRange = false;
            OnTargetExitedRange?.Invoke();
        }
    }

    private bool IsPlayer(Collider other)
    {
        return other.TryGetComponent<Player>(out _);
    }
}