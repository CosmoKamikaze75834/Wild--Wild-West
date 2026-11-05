using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WindowDefeat : Window
{
    [SerializeField] private Button _buttonMainMenu;

    private SceneLoader _sceneLoader;
    private GameplayPause _pause;

    private void Start()
    {
        Close();
    }

    private void OnEnable()
    {
        _buttonMainMenu.onClick.AddListener(OnMenuClicked);
    }

    private void OnDisable()
    {
        _buttonMainMenu.onClick.RemoveListener(OnMenuClicked);
    }

    private void OnMenuClicked()
    {
        _sceneLoader.Load("MainMenuScene");
        _pause.CancelPause();
    }

    [Inject]
    private void Construct(SceneLoader sceneLoader, GameplayPause gameplayPause)
    {
        _sceneLoader = sceneLoader;
        _pause = gameplayPause;
    }
}