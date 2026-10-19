using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimationHandler : MonoBehaviour, IAnimationEnemy
{
    private static readonly int Attack = Animator.StringToHash(nameof(Attack));

    private Animator _animator;

    public event Action AttackHit;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TriggerAttack()
    {
        _animator.SetTrigger(Attack);
    }

    public void OnAttackHit()
    {
        AttackHit?.Invoke();
    }
}