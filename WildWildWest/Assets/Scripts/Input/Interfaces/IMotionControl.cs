using UnityEngine;

public interface IMotionControl
{
    Vector2 MoveDirection { get; }
    public bool IsJump { get; }
}