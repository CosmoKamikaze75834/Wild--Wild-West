using UnityEngine;
using Zenject;

public class InputSystem : MonoBehaviour, IMotionControl, IMotionRotation
{
    private InputMove _inputMove;
    private InputRotation _inputRotation;
    private InputJump _inputJump;

    public Vector2 MoveDirection => _inputMove.MoveDirection;
    public Vector2 MouseRotation => _inputRotation.MouseRotation;
    public bool IsJump => _inputJump.IsJump;

    [Inject]
    private void Construct(InputMove inputMove, InputRotation inputRotation, InputJump inputJump)
    {
        _inputMove = inputMove;
        _inputRotation = inputRotation;
        _inputJump = inputJump;
    }
}