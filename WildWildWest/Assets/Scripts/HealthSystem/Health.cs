using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    private const float MinHealth = 0;
    private const float MinHDamage = 0;

    [SerializeField, Min(1)] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    public float MaxHealth => _maxHealth;

    public event Action OnDied;
    public event Action OnDamaged;
    public event Action<float> HealthChanged;

    public void TakeDamage(float damage)
    {
        if (IsDead())
            return;

        if (damage <= MinHDamage)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _currentHealth -= damage;

        if(_currentHealth < MinHealth)
            _currentHealth = MinHealth;

        HealthChanged?.Invoke(_currentHealth);

        OnDamaged?.Invoke();

        if (IsDead())
            OnDied?.Invoke();
    }

    public void Reset()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth);
    }

    private bool IsDead()
    {
        return _currentHealth <= MinHealth;
    }
}