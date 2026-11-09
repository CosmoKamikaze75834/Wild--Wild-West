using UnityEngine;
using Zenject;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Turner _turner;
    [SerializeField] private Runner _runner;
    [SerializeField] private Health _health;

    private Movement _movement;
    private CameraRotation _cameraRotation;

    private void Start()
    {
        Cursor.visible = false;
        _health.Reset();
    }

    private void Update()
    {
        _runner.UpdateRunState();
        _movement.Move(_cameraRotation.GetForwardOnGround(), _cameraRotation.GetRightOnGround(), _jumper.GetVerticalVelocity(_movement.CharacterController));
    }

    [Inject]
    private void Construct(Movement movement,CameraRotation cameraRotation)
    {
        _movement = movement;
        _cameraRotation = cameraRotation;
    }
}