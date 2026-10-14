using UnityEngine;
using Zenject;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private CameraRotation _cameraRotation;
    [SerializeField] private Turner _turner;

    [Inject]
    private void Construct(Movement movement,CameraRotation cameraRotation)
    {
        _movement = movement;
        _cameraRotation = cameraRotation;
    }

    private void Update()
    {
        _movement.Move(_cameraRotation.GetForwardOnGround(), _cameraRotation.GetRight(), _jumper.GetVerticalVelocity(_movement.CharacterController));
    }
}