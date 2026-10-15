using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public event Action EnemyDied;

    public void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }

    public void ChangeStates(Vector3 position)
    {
        transform.position = position;
        transform.rotation = Quaternion.identity;
    }
}