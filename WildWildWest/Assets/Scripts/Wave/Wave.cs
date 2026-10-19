using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Wave/Create new Wave", order = 51)]
public class Wave : ScriptableObject
{
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _enemySpawnInterval;

    public int EnemyCount => _enemyCount;
    public float EnemySpawnInterval => _enemySpawnInterval;
}