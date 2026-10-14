using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationHandler : MonoBehaviour, IAnimationPlayer
{
    private static readonly int Speed = Animator.StringToHash(nameof(Speed));//скорость
    private static readonly int IsJump = Animator.StringToHash(nameof(IsJump));//прыжок

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
}