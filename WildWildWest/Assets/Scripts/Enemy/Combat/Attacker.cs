using UnityEngine;
using Zenject;

public class Attacker : MonoBehaviour
{
    private const float AttackDelay = 2f;

    [SerializeField, Min(1)] private float _damage;

    private float _nextAttackTime; 

    private IDamageable _damageable;
    private IAnimationEnemy _animationEnemy;

    private AttackRangeChecker _attackRangeChecker;

    private void OnDestroy()
    {
        _animationEnemy.AttackHit -= HandleAttackHit;
    }

    public void Attack()
    {
        if (Time.time >= _nextAttackTime)
        {
            _animationEnemy.TriggerAttack();
            _nextAttackTime = AttackDelay + Time.time;
        }
    }

    private void HandleAttackHit()
    {
        if(_attackRangeChecker.IsTargetInRange)
            _damageable.TakeDamage(_damage);
    }

    [Inject]
    private void Construct(IDamageable damageable, IAnimationEnemy animationEnemy, AttackRangeChecker attackRangeChecker)
    {
        _damageable = damageable;
        _animationEnemy = animationEnemy;
        _attackRangeChecker = attackRangeChecker;

        _animationEnemy.AttackHit += HandleAttackHit;
    }
}