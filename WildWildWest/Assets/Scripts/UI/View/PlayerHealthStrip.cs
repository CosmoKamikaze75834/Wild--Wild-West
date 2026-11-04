using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthStrip : MonoBehaviour
{
    [SerializeField] private Image _bar;

    public void ChangeBar(float amount)
    {
        _bar.fillAmount = Mathf.Clamp01(amount);
    }
}