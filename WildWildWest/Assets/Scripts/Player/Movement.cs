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

    public CharacterController CharacterController => _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    public void Move(Vector3 forward, Vector3 right, Vector3 verticalVelocity)
    {
        Vector2 input = Vector2.ClampMagnitude(_motionControl.MoveDirection, ValidVectorLength);

        var playerInput = right * input.x + forward * input.y;
        playerInput *= _speed;

        playerInput.y = verticalVelocity.y;
        _controller.Move(playerInput * Time.deltaTime);

        _animationPlayer.EstablishSpeed(input.magnitude);
    }

    [Inject]
    private void Construct(IMotionControl motionControl, IAnimationPlayer animationPlayer)
    {
        _motionControl = motionControl;
        _animationPlayer = animationPlayer;
    }
}