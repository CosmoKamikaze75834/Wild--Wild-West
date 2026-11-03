using UnityEngine;

public class EnemyDamagePresenter : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private EnemyDamageView _damageView;

    private void OnEnable()
    {
        _health.OnDamaged += _damageView.ShowDamage;
    }

    private void OnDisable()
    {
        _health.OnDamaged -= _damageView.ShowDamage;
    }
}