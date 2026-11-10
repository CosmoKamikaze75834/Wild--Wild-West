using Zenject;

public class WindowLoading : Window
{
    private const string SceneName = "GameplayScene";

    private SceneLoader _sceneLoader;

    private void Start()
    {
        StartCoroutine(_sceneLoader.LoadAsync(SceneName));
    }

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
}