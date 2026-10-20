using UnityEngine;
using Zenject;

public class Turner : MonoBehaviour
{
    [SerializeField] private float _horizontalTurnSensitivity = 0.1f;

    private IMotionRotation _motionRotation;

    private void Update()
    {
        var rotation = _motionRotation.MouseRotation.x * _horizontalTurnSensitivity;
        transform.Rotate(rotation * Vector3.up, Space.World);
    }

    [Inject]
    private void Construct(IMotionRotation motionRotation)
    {
        _motionRotation = motionRotation;
    }
}