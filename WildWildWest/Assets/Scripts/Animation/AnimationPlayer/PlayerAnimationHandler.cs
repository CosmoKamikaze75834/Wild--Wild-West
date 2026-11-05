using System;
using UnityEngine;

public class PlayerAnimationHandler : AnimationHandlerBase, IAnimationPlayer
{
    [SerializeField] private WeaponAnimationEvents _animationEvents;

    private static readonly int Speed = Animator.StringToHash(nameof(Speed));
    private static readonly int IsJump = Animator.StringToHash(nameof(IsJump));
    private static readonly int IsRun = Animator.StringToHash(nameof(IsRun));
    private static readonly int ShootPistol = Animator.StringToHash(nameof(ShootPistol));
    private static readonly int AttackShovel = Animator.StringToHash(nameof(AttackShovel));
    private static readonly int ForwardDirection = Animator.StringToHash(nameof(ForwardDirection));

    public event Action ShovelHit;

    private void OnEnable()
    {
        _animationEvents.ShovelHit += HandleShovelHit;
    }

    private void OnDisable()
    {
        _animationEvents.ShovelHit -= HandleShovelHit;
    }

    private void HandleShovelHit()
    {
        ShovelHit?.Invoke();
    }

    public void EstablishSpeed(float movement)
    {
        _animator.SetFloat(Speed, Mathf.Abs(movement));
    }

    public void EstablishForwardDirection(float direction)
    {
        _animator.SetFloat(ForwardDirection, direction);
    }

    public void EstablishJump(bool isJumping)
    {
        _animator.SetBool(IsJump, isJumping);
    }

    public void EstablishRun(bool isRunning)
    {
        _animator.SetBool(IsRun, isRunning);
    }

    public void TriggerAttackPistol()
    {
        _animator.SetTrigger(ShootPistol);
    }

    public void TriggerAttackShovel()
    {
        _animator.SetTrigger(AttackShovel);
    }
}