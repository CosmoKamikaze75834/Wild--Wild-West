using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    [SerializeField] private Wave _wave;
    [SerializeField] private Spawner _spawner;

    private void Start()
    {
        LaunchWave();
    }

    public void LaunchWave()
    {
        _spawner.StartSpawning(_wave.EnemyCount, _wave.EnemySpawnInterval);
    }
}