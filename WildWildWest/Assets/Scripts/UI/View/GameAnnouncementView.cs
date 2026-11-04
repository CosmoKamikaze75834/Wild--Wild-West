using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class GameAnnouncementView : MonoBehaviour
{
    private const int Time = 2;

    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private RectTransform _rectTransform;

    [SerializeField] private float _numberDown;
    [SerializeField] private float _numberUp;
    [SerializeField] private float _duration;

    public IEnumerator PlayAnimation()
    {
        yield return ChangePosition(_numberDown).WaitForCompletion();

        yield return new WaitForSeconds(Time);

        yield return ChangePosition(_numberUp).WaitForCompletion();
    }

    public void ChangeTextWave(int numberWave)
    {
        _text.text = $"Волна {numberWave}!\nПриготовься к бою";
    }

    public void ChangeTextBoss()
    {
        _text.text = $"Появление босса!\nПриготовься к бою";
    }

    private Tween ChangePosition(float number)
    {
        return _rectTransform.DOAnchorPos(new Vector2(0, number), _duration);
    }
}