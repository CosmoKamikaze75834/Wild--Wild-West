using System;
using UnityEngine;

public class EnemyAnimationHandler : AnimationHandlerBase, IAnimationEnemy
{
    private static readonly int Attack = Animator.StringToHash(nameof(Attack));

    public event Action AttackHit;

    public void TriggerAttack()
    {
        _animator.SetTrigger(Attack);
    }

    public void OnAttackHit()
    {
        AttackHit?.Invoke();
    }
}