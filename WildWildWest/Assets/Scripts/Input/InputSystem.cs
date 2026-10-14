using UnityEngine;
using Zenject;

public class InputSystem : MonoBehaviour, IMotionControl, IMotionRotation
{
    private InputMove _inputMove;
    private InputRotation _inputRotation;
    private InputJump _inputJump;
    private InputRun _inputRun;

    public Vector2 MoveDirection => _inputMove.MoveDirection;
    public Vector2 MouseRotation => _inputRotation.MouseRotation;

    public bool IsJump => _inputJump.IsJump;
    public bool IsRunning => _inputRun.IsRunning;

    [Inject]
    private void Construct(InputMove inputMove, InputRotation inputRotation, InputJump inputJump, InputRun inputRun)
    {
        _inputMove = inputMove;
        _inputRotation = inputRotation;
        _inputJump = inputJump;
        _inputRun = inputRun;
    }
}