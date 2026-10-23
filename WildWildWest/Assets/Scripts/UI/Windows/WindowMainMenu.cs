//обрабатывает нажатие кнопки Play
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WindowMainMenu : Window
{
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
        _sceneLoader.Load("LoadingScene");
    }

    private void OnExitClicked()
    {
        Application.Quit();
        Debug.Log("Вы вышли из игры");
    }

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
}