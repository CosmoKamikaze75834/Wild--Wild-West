using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class WaveAnnouncementView : MonoBehaviour
{
    private const int Time = 2;

    [SerializeField] private TextMeshProUGUI _textWave;
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

    public void Change(int numberWave)
    {
        _textWave.text = $"Волна {numberWave}!\nПриготовься к бою";
    }

    private Tween ChangePosition(float number)
    {
        return _rectTransform.DOAnchorPos(new Vector2(0, number), _duration);
    }
}