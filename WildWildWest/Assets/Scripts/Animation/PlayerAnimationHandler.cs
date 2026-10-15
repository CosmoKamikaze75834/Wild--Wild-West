using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationHandler : MonoBehaviour, IAnimationPlayer
{
    private static readonly int Speed = Animator.StringToHash(nameof(Speed));//скорость
    private static readonly int IsJump = Animator.StringToHash(nameof(IsJump));//прыжок
    private static readonly int IsRun = Animator.StringToHash(nameof(IsRun));//прыжок
    private static readonly int ShootPistol = Animator.StringToHash(nameof(ShootPistol));//атака
    private static readonly int AttackShovel = Animator.StringToHash(nameof(AttackShovel));//атака

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    //состояние для ходьбы
    public void EstablishSpeed(float movement)
    {
        _animator.SetFloat(Speed, Mathf.Abs(movement));
    }

    //прыжок
    public void EstablishJump(bool isJumping)
    {
        _animator.SetBool(IsJump, isJumping);
    }

    //бег
    public void EstablishRun(bool isRunning)
    {
        _animator.SetBool(IsRun, isRunning);
    }

    //запускаем триггер атаки
    public void TriggerAttackPistol()
    {
        _animator.SetTrigger(ShootPistol);
    }

    //запускаем триггер атаки
    public void TriggerAttackShovel()
    {
        _animator.SetTrigger(AttackShovel);
    }
}