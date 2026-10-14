using UnityEngine;
using Zenject;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _gravityFactor = 2f;
    [SerializeField] private float _jumpForce = 5f;

    private IMotionControl _motionControl;

    private Vector3 _verticalVelocity;

    public Vector3 GetVerticalVelocity(CharacterController characterController)
    {
        if (characterController.isGrounded)
        {
            if (_motionControl.IsJump)
                _verticalVelocity = Vector3.up * _jumpForce;
            else
                _verticalVelocity = Vector3.down;
        }
        else
            _verticalVelocity += Physics.gravity * Time.deltaTime * _gravityFactor;

        return _verticalVelocity;
    }

    [Inject]
    private void Construct(IMotionControl motionControl)
    {
        _motionControl = motionControl;
    }
}