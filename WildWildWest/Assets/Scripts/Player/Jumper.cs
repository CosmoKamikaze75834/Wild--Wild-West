using UnityEngine;
using Zenject;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _gravityFactor = 2f;
    [SerializeField] private float _jumpForce = 5f;

    private IMotionControl _motionControl;
    private IAnimationPlayer _animationPlayer;

    private Vector3 _verticalVelocity;

    private bool _canJump = true;

    public Vector3 GetVerticalVelocity(CharacterController characterController)
    {
        if (characterController.isGrounded)
        {
            if (_motionControl.IsJump && _canJump)
            {
                _verticalVelocity = Vector3.up * _jumpForce;
                _animationPlayer.EstablishJump(true);
                _canJump = false;
            }
            else
            {
                _verticalVelocity = Vector3.down;
                _animationPlayer.EstablishJump(false);
                if (!_motionControl.IsJump)
                    _canJump = true;
            }
        }
        else
        {
            _verticalVelocity += Physics.gravity * Time.deltaTime * _gravityFactor;
            _animationPlayer.EstablishJump(true);
            _canJump = false;
        }

        return _verticalVelocity;
    }

    [Inject]
    private void Construct(IMotionControl motionControl, IAnimationPlayer animationPlayer)
    {
        _motionControl = motionControl;
        _animationPlayer = animationPlayer;
    }
}