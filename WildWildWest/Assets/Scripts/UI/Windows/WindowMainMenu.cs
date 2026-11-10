using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WindowMainMenu : Window
{
    private const string SceneName = "LoadingScene";

    [SerializeField] private Button _buttonPlay;
    [SerializeField] private Button _buttonExit;

    private SceneLoader _sceneLoader;

    private void OnEnable()
    {
        _buttonPlay.onClick.AddListener(OnPlayClicked);
        _buttonExit.onClick.AddListener(OnExitClicked);
    }

    private void OnDisable()
    {
        _buttonPlay.onClick.RemoveListener(OnPlayClicked);
        _buttonExit.onClick.RemoveListener(OnExitClicked);
    }

    private void OnPlayClicked()
    {
        _sceneLoader.Load(SceneName);
    }

    private void OnExitClicked()
    {
        Application.Quit();
    }

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
}