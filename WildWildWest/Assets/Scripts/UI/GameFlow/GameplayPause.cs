using UnityEngine;
using Zenject;

public class GameplayPause : MonoBehaviour
{
    private const float TimePause = 0;
    private const float TimePlay = 1;
    
    private PlayerInputHandler _inputHandler;

    public void EstablishPause()
    {
        _inputHandler.DisablePlayerInput();
        Time.timeScale = TimePause;
    }

    public void CancelPause()
    {
        _inputHandler.EnablePlayerInput();
        Time.timeScale = TimePlay;
    }

    [Inject]
    private void Construct(PlayerInputHandler playerInput)
    {
        _inputHandler = playerInput;
    }
}