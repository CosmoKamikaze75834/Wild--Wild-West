using UnityEngine;
using Zenject;

public class InputSystem : MonoBehaviour, IMotionControl, IMotionRotation
{
    private InputMove _inputMove;
    private InputRotation _inputRotation;

    public Vector2 MoveDirection => _inputMove.MoveDirection;

    public Vector2 MouseRotation => _inputRotation.MouseRotation;

    [Inject]
    private void Construct(InputMove inputMove, InputRotation inputRotation)
    {
        _inputMove = inputMove;
        _inputRotation = inputRotation;
    }
}