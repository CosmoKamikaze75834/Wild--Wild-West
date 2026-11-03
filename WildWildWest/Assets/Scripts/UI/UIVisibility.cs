using UnityEngine;

public abstract class UIVisibility : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    protected CanvasGroup UIGroup => _canvasGroup;

    public virtual void Open()
    {
        _canvasGroup.alpha = 1f;
    }

    public virtual void Close()
    {
        _canvasGroup.alpha = 0f;
    }
}