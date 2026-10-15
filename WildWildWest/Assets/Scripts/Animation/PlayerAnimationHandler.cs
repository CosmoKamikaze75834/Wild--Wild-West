using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationHandler : MonoBehaviour, IAnimationPlayer
{
    private static readonly int Speed = Animator.StringToHash(nameof(Speed));
    private static readonly int IsJump = Animator.StringToHash(nameof(IsJump));
    private static readonly int IsRun = Animator.StringToHash(nameof(IsRun));
    private static readonly int ShootPistol = Animator.StringToHash(nameof(ShootPistol));
    private static readonly int AttackShovel = Animator.StringToHash(nameof(AttackShovel));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void EstablishSpeed(float movement)
    {
        _animator.SetFloat(Speed, Mathf.Abs(movement));
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