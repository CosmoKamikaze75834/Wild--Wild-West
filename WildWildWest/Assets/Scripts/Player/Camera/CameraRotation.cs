using UnityEngine;
using Zenject;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private float _verticalTurnSensitivity = 0.1f;

    [SerializeField] private float _verticalMinAngle = -89f;
    [SerializeField] private float _verticalMaxAngle = 90f;

    private float _cameraAngle = 0f;//текущий угол поворота камеры

    private IMotionRotation _motionRotation;

    private void Awake()
    {
        _cameraAngle = Mathf.DeltaAngle(0f, _cameraTransform.localEulerAngles.x);
        _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
    }

    private void Update()
    {
        RotateCameraVertical();
    }

    public void RotateCameraVertical()
    {
        _cameraAngle -= _motionRotation.MouseRotation.y * _verticalTurnSensitivity;
        _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
        _cameraTransform.localRotation = Quaternion.Euler(_cameraAngle, 0f, 0f);
    }

    //проецирует вектор на плоскость, нормаль которой Vector3.up, и нормализует его
    public Vector3 GetForwardOnGround() => 
        Vector3.ProjectOnPlane(_cameraTransform.forward, Vector3.up).normalized;

    public Vector3 GetRight() =>
        Vector3.ProjectOnPlane(_cameraTransform.right, Vector3.up).normalized;

    [Inject]//сообщает что нужно внедрить зависимость
    private void Construct(IMotionRotation motionRotation)
    {
        _motionRotation = motionRotation;
    }
}
