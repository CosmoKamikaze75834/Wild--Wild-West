using UnityEngine;
using Zenject;

public class InputSystem : MonoBehaviour, IMotionControl, IMotionRotation, IWeaponInput
{
    private InputMove _inputMove;
    private InputRotation _inputRotation;
    private InputJump _inputJump;
    private InputRun _inputRun;
    private InputAttack _inputAttack;
    private InputScroll _inputScroll;

    public Vector2 MoveDirection => _inputMove.MoveDirection;
    public Vector2 MouseRotation => _inputRotation.MouseRotation;
    public Vector2 ScrollDelta => _inputScroll.ScrollDelta;

    public bool IsJump => _inputJump.IsJump;
    public bool IsRunning => _inputRun.IsRunning;
    public bool IsAttack => _inputAttack.IsAttack;

    public Vector2 ConsumeScrollDelta() =>
       _inputScroll.ConsumeScrollDelta();

    [Inject]
    private void Construct(InputMove inputMove, InputRotation inputRotation, InputJump inputJump, InputRun inputRun, InputAttack inputAttack, InputScroll inputScroll)
    {
        _inputMove = inputMove;
        _inputRotation = inputRotation;
        _inputJump = inputJump;
        _inputRun = inputRun;
        _inputAttack = inputAttack;
        _inputScroll = inputScroll;
    }
}