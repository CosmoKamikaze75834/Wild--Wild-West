using UnityEngine;

public class EnemyDamagePresenter : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Enemy _enemy;

    [SerializeField] private EnemyDamageView _damageView;
    [SerializeField] private EnemyDeadView _deadView;

    private void OnEnable()
    {
        _health.OnDamaged += _damageView.ShowDamage;
        _enemy.Died += Create;
    }

    private void OnDisable()
    {
        _health.OnDamaged -= _damageView.ShowDamage;
        _enemy.Died -= Create;

    }

    private void Create(Enemy enemy, Vector3 position)
    {
        _deadView.CreateEffect(position);
    }
}