using UnityEngine;
using Zenject;

//управляет частотой аттак и их запуском
public class Attacker : MonoBehaviour
{
    [SerializeField, Min(1)] private float _damage;

    private float _attackDelay = 2f;// Задержка между атаками (в секундах)
    private float _nextAttackTime; // Время, когда враг сможет атаковать следующий раз

    private IDamageable _damageable;
    private IAnimationEnemy _animationEnemy;
    private AttackRangeChecker _attackRangeChecker;

    private void OnDestroy()
    {
        _animationEnemy.AttackHit -= CallDamage;
    }

    public void Attack()
    {
        if (Time.time >= _nextAttackTime)
        {
            _animationEnemy.TriggerAttack();
            _nextAttackTime = _attackDelay + Time.time;// Устанавливаем время следующей атаки
        }
    }

    [Inject]
    private void Construct(IDamageable damageable, IAnimationEnemy animationEnemy, AttackRangeChecker attackRangeChecker)
    {
        _damageable = damageable;
        _animationEnemy = animationEnemy;
        _attackRangeChecker = attackRangeChecker;

        _animationEnemy.AttackHit += CallDamage;
    }

    private void CallDamage()
    {
        if(_attackRangeChecker.IsTargetInRange)
            _damageable.TakeDamage(_damage);
    }
}