using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    private const float MinHealth = 0;
    private const float MinHDamage = 0;

    [SerializeField, Min(1)] private float _maxHealth;
    [SerializeField] public float _currentHealth;

    public event Action OnDied;

    public void TakeDamage(float damage)
    {
        if (IsDead())
            return;

        if (damage <= MinHDamage)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _currentHealth -= damage;

        if (IsDead())
        {
            _currentHealth = MinHealth;
            OnDied?.Invoke();
        }
    }

    public void Reset()
    {
        _currentHealth = _maxHealth;
    }

    private bool IsDead()
    {
        return _currentHealth <= MinHealth;
    }
}