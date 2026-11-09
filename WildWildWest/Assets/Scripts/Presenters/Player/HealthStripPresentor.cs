using UnityEngine;

public class HealthStripPresentor : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerHealthStrip _healthStrip;

    private void OnEnable()
    {
        _health.HealthChanged += Convert;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= Convert;
    }

    private void Convert(float currentHealth)
    {
        _healthStrip.ChangeBar(currentHealth/_health.MaxHealth);
    }
}