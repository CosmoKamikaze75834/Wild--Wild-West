using UnityEngine;
using Zenject;

public class PlayerInputHandler : MonoBehaviour, IMotionControl, IMotionRotation, IWeaponInput
{
    private PlayerInput _playerInput;

    private InputMove _inputMove;
    private InputRotation _inputRotation;
    private InputJump _inputJump;
    private InputRun _inputRun;
    private InputAttack _inputAttack;
    private InputScroll _inputScroll;
    private InputAim _inputAim;

    public Vector2 MoveDirection => _inputMove.MoveDirection;
    public Vector2 MouseRotation => _inputRotation.MouseRotation;
    public Vector2 ScrollDelta => _inputScroll.ScrollDelta;

    public bool IsJump => _inputJump.IsJump;
    public bool IsRunning => _inputRun.IsRunning;
    public bool IsAttack => _inputAttack.IsAttack;

    public bool IsAiming => _inputAim.IsAiming;

    public Vector2 ConsumeScrollDelta() =>
       _inputScroll.ConsumeScrollDelta();

    public void DisablePlayerInput()
    {
        _playerInput.Player.Disable();
    }

    public void EnablePlayerInput()
    {
        _playerInput.Player.Enable();
    }

    [Inject]
    private void Construct(InputMove inputMove, InputRotation inputRotation, InputJump inputJump, 
        InputRun inputRun, InputAttack inputAttack, InputScroll inputScroll, PlayerInput inputActions, InputAim inputAim)
    {
        _inputMove = inputMove;
        _inputRotation = inputRotation;
        _inputJump = inputJump;
        _inputRun = inputRun;
        _inputAttack = inputAttack;
        _inputScroll = inputScroll;
        _playerInput = inputActions;
        _inputAim = inputAim;
    }
}