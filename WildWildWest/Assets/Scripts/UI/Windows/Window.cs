using UnityEngine;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;

    protected CanvasGroup WindowGroup => _windowGroup;

    //открытие окна
    public void Open()
    {
        _windowGroup.alpha = 1f;
        _windowGroup.interactable = true;
        _windowGroup.blocksRaycasts = true;//перехватывает райкаст
    }

    //закрытие
    public void Close()
    {
        _windowGroup.alpha = 0f;
        _windowGroup.interactable = false;
        _windowGroup.blocksRaycasts = false;
    }
}