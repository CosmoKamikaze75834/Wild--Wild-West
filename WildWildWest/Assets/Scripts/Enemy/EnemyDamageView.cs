using System.Collections;
using UnityEngine;

public class EnemyDamageView : MonoBehaviour
{
    private const string ColorProperty = "_Color";

    [SerializeField] private SkinnedMeshRenderer _meshRenderer;
    [SerializeField] private Color _color;
    [SerializeField] private float _time = 1f;

    private MaterialPropertyBlock _propertyBlock;
    private Color _originalColor;
    private Coroutine _currentCoroutine;

    private void Awake()
    {
        _propertyBlock = new MaterialPropertyBlock();
        _originalColor = _meshRenderer.sharedMaterial.GetColor(ColorProperty);
    }

    public void ShowDamage()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        SetColor(_color);

        yield return new WaitForSeconds(_time);

        SetColor(_originalColor);
        _currentCoroutine = null;
    }

    private void SetColor(Color color)
    {
        _meshRenderer.GetPropertyBlock(_propertyBlock);
        _propertyBlock.SetColor(ColorProperty, color);
        _meshRenderer.SetPropertyBlock(_propertyBlock);
    }

    private void OnDisable()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }

        if (_propertyBlock != null)
            SetColor(_originalColor);
    }
}