using UnityEngine;

public abstract class UIVisibility : MonoBehaviour
{
    private const float Hidden = 0f;
    private const float Visible = 1f;

    [SerializeField] private CanvasGroup _canvasGroup;

    protected CanvasGroup UIGroup => _canvasGroup;

    public virtual void Open()
    {
        _canvasGroup.alpha = Visible;
    }

    public virtual void Close()
    {
        _canvasGroup.alpha = Hidden;
    }
}