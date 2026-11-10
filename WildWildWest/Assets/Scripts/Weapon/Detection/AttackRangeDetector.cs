using System.Collections.Generic;
using UnityEngine;

public class AttackRangeDetector : MonoBehaviour
{
    [SerializeField] private float _radiusFinder;
    [SerializeField] private Transform _pointFinder;
    [SerializeField] private LayerMask _layerMask;

    public List<IDamageable> GetObjectsRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(_pointFinder.position, _radiusFinder, _layerMask);

        List<IDamageable> enemies = new();

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IDamageable enemy) && !enemies.Contains(enemy))
                enemies.Add(enemy);
        }

        return enemies;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_pointFinder.position, _radiusFinder);
    }
}