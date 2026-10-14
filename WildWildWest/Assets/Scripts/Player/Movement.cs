using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    private const float ValidVectorLength = 1f;

    [Range(0, 10)]
    [SerializeField] private float _speed;

    private CharacterController _controller;
    private IMotionControl _motionControl;
    private IAnimationPlayer _animationPlayer;

    private float _verticalVelocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector2 input = Vector2.ClampMagnitude(_motionControl.MoveDirection, ValidVectorLength);

        var playerInput = new Vector3(input.x, 0, input.y);
        playerInput *= _speed;

        UpdateVerticalVelocity();

        playerInput.y = _verticalVelocity;
        _controller.Move(playerInput * Time.deltaTime);

        _animationPlayer.EstablishSpeed(input.magnitude);
    }

    private void UpdateVerticalVelocity()
    {
        if (_controller.isGrounded && _verticalVelocity < 0f)
            _verticalVelocity = -2f;
        else
            _verticalVelocity += Physics.gravity.y * Time.deltaTime;
    }

    [Inject]//сообщает что нужно внедрить зависимость
    private void Construct(IMotionControl motionControl, IAnimationPlayer animationPlayer)
    {
        _motionControl = motionControl;
        _animationPlayer = animationPlayer;
    }
}