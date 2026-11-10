using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class GameAnnouncementView : MonoBehaviour
{
    private const int TextHoldDuration = 2;
    private const float TargetXPosition = 0f;

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private RectTransform _rectTransform;

    [SerializeField] private float _visibleYPosition;
    [SerializeField] private float _hiddenYPosition;
    [SerializeField, Min(0f)] private float _moveDuration;

    public IEnumerator PlayAnimation()
    {
        yield return ChangePosition(_visibleYPosition).WaitForCompletion();
        yield return new WaitForSeconds(TextHoldDuration);
        yield return ChangePosition(_hiddenYPosition).WaitForCompletion();
    }

    public void ChangeTextWave(int numberWave)
    {
        _text.text = $"Волна {numberWave}!\nПриготовься к бою";
    }

    public void ChangeTextBoss()
    {
        _text.text = "Появление босса!\nПриготовься к бою";
    }

    private Tween ChangePosition(float targetYPosition)
    {
        return _rectTransform.DOAnchorPos(new Vector2(TargetXPosition, targetYPosition), _moveDuration);
    }
}