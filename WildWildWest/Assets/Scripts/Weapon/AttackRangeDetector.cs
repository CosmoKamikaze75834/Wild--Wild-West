using System.Collections.Generic;
using UnityEngine;

public class AttackRangeDetector : MonoBehaviour
{
    [SerializeField] private float _radiusFinder;
    [SerializeField] private Transform _pointFinder;

    //вернёт список объектов типа врага в радиусе атаки
    public List<Enemy> GetObjectsRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(_pointFinder.position, _radiusFinder);

        List<Enemy> enemies = new();

        foreach (Collider collider in colliders)
        {
            var enemy = collider.GetComponentInParent<Enemy>();

            if(enemy != null && !enemies.Contains(enemy))
                enemies.Add(enemy);
        }

        return enemies;
    }

    private void OnDrawGizmos()
    {
        Color color = Color.red;
        Gizmos.DrawWireSphere(_pointFinder.position, _radiusFinder);
    }
}