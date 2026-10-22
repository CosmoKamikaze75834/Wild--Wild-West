using UnityEngine;
using Zenject;

public class WindowLoading : Window
{
    [SerializeField] private RectTransform _tumbleweed;

    private SceneLoader _sceneLoader;

    private float _startX;
    private float _endX;

    private void Start()
    {
        RectTransform parent = (RectTransform)_tumbleweed.parent;

        float halfWidth = parent.rect.width / 2f;
        float halfTumbleweedWidth = _tumbleweed.rect.width / 2f;

        _startX = -halfWidth - halfTumbleweedWidth;
        _endX = halfWidth + halfTumbleweedWidth;

        UpdateTumbleweedPosition(0f);

        StartCoroutine(_sceneLoader.LoadAsync("GameplayScene", UpdateTumbleweedPosition));
    }

    private void UpdateTumbleweedPosition(float progress)
    {
        float positionX = Mathf.Lerp(_startX, _endX, progress);

        Vector2 position = _tumbleweed.anchoredPosition;
        position.x = positionX;

        _tumbleweed.anchoredPosition = position;
    }


    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
}