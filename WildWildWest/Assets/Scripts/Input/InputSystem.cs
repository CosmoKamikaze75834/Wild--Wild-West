using UnityEngine;

public class InputSystem : MonoBehaviour, IMotionControl
{
    [SerializeField] private InputMove _inputMove;

    public Vector2 MoveDirection => _inputMove.MoveDirection;


}