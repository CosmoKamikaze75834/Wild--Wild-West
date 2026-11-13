using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField, Min(1)] private float _damage;

    protected float Damage => _damage;

    public abstract void Attack();

    protected void ApplyDamage(IDamageable target)
    {
        if (target == null)
            return;

        target.TakeDamage(_damage);
    }
}