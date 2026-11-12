using UnityEngine;
using Zenject;

public class CameraRotation : MonoBehaviour
{
    private const float ZeroAngle = 0f;

    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private float _verticalTurnSensitivity = 0.1f;
    [SerializeField] private float _verticalMinAngle = -89f;
    [SerializeField] private float _verticalMaxAngle = 89f;

    private float _cameraAngle = 0f;

    private IMotionRotation _motionRotation;

    private void Awake()
    {
        _cameraAngle = Mathf.DeltaAngle(ZeroAngle, _cameraTransform.localEulerAngles.x);
        _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
    }

    private void LateUpdate()
    {
        RotateCameraVertical();
    }

    public Vector3 GetForwardOnGround() => 
        Vector3.ProjectOnPlane(_cameraTransform.forward, Vector3.up).normalized;

    public Vector3 GetRightOnGround() =>
        Vector3.ProjectOnPlane(_cameraTransform.right, Vector3.up).normalized;

    private void RotateCameraVertical()
    {
        _cameraAngle -= _motionRotation.MouseRotation.y * _verticalTurnSensitivity;
        _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
        _cameraTransform.localRotation = Quaternion.Euler(_cameraAngle, ZeroAngle, ZeroAngle);
    }

    [Inject]
    private void Construct(IMotionRotation motionRotation)
    {
        _motionRotation = motionRotation;
    }
}