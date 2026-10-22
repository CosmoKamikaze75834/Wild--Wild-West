//обрабатывает нажатие кнопки Play
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WindowMainMenu : Window
{
    [SerializeField] private Button _button;

    private SceneLoader _sceneLoader;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnPlayClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnPlayClicked);
    }

    private void OnPlayClicked()
    {
        _sceneLoader.Load("LoadingScene");
    }

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
}