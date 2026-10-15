using UnityEngine;
using Zenject;

public class Runner : MonoBehaviour
{
    private IMotionControl _motionControl;
    private IAnimationPlayer _animationPlayer;

    private float _maxSpeed = 10f;

    public void Speed(Movement movement)
    {
        if (_motionControl.IsRunning)
        {
            movement.ChangeSpeed(_maxSpeed);//изменяется скорость на макс
            _animationPlayer.EstablishRun(true);
        }
        else
        {
            movement.ChangeSpeed(movement.DefaultSpeed);
            _animationPlayer.EstablishRun(false);
        }
    }

    [Inject]
    private void Construct(IMotionControl motionControl, IAnimationPlayer animationPlayer)
    {
        _motionControl = motionControl;
        _animationPlayer = animationPlayer;
    }
}