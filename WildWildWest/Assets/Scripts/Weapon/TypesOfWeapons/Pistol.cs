using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private RaycastLaunch _launch;

    public override void Attack()
    {
        if (_launch.TryGetHit(out RaycastHit hitInfo))
        {
            IDamageable target = hitInfo.collider.GetComponentInChildren<IDamageable>();

            if (target != null)
                ApplyDamage(target);
        }
    }
}