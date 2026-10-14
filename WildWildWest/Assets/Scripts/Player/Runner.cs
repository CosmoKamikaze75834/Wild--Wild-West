using UnityEngine;
using Zenject;

public class Runner : MonoBehaviour
{
    private IMotionControl _motionControl;

    private float _maxSpeed = 10f;

    public void Speed(Movement movement)
    {
        if(_motionControl.IsRunning)
            movement.ChangeSpeed(_maxSpeed);//изменяется скорость на макс
        else
            movement.ChangeSpeed(movement.DefaultSpeed);
    }

    [Inject]
    private void Construct(IMotionControl motionControl)
    {
        _motionControl = motionControl;
    }
}