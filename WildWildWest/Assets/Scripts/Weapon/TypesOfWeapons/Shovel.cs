using System.Collections.Generic;
using UnityEngine;

public class Shovel : Weapon
{
    [SerializeField] private AttackRangeDetector _attackRangeDetector;

    public override void Attack()
    {
        List<Enemy> enemies = _attackRangeDetector.GetObjectsRadius();

        foreach (var item in enemies)
            ApplyDamage((IDamageable)item);
    }
}