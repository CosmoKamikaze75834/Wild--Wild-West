using UnityEngine;
using Zenject;

//управляет частотой аттак и их запуском
public class Attacker : MonoBehaviour
{
    [SerializeField, Min(1)] private float _damage;

    private float _attackDelay = 2f;// Задержка между атаками (в секундах)
    private float _nextAttackTime; // Время, когда враг сможет атаковать следующий раз

    private IDamageable _damageable;

    public void Attack()
    {
        Debug.Log("Перешли в состоянии атаки и атакуем");

        if (Time.time >= _nextAttackTime)
        {
            _damageable.TakeDamage(_damage);
            _nextAttackTime = _attackDelay + Time.time;// Устанавливаем время следующей атаки
        }
    }

    [Inject]
    private void Construct(IDamageable damageable)
    {
        _damageable = damageable;
    }
}