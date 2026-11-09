using UnityEngine;
using Zenject;

public class Runner : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 10f;

    private IMotionControl _motionControl;
    private IPlayerMovementAnimation _animationPlayer;
    private Movement _movement;

    public void UpdateRunState()
    {
        bool isRunning = _motionControl.IsRunning;

        float speed = isRunning ? _runSpeed : _movement.DefaultSpeed;

        _movement.ChangeSpeed(speed);
        _animationPlayer.UpdateRunState(isRunning);
    }

    [Inject]
    private void Construct(IMotionControl motionControl, IPlayerMovementAnimation animationPlayer, Movement movement)
    {
        _motionControl = motionControl;
        _animationPlayer = animationPlayer;
        _movement = movement;
    }
}