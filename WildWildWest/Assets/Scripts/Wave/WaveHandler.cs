using System;
using System.Threading.Tasks;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    [SerializeField] private Wave _wave;
    [SerializeField] private Spawner _spawner;

    private async void Start()
    {
        try
        {
            await LaunchWave();//ждёт пока спавнер закончит создание вргаов
            Debug.Log("Все враги появились");
        }
        catch (OperationCanceledException)
        {
            Debug.Log("Спавн врагов отменён");
        }
        catch(Exception exception)
        {
            Debug.LogException(exception);
        }
    }

    public Task LaunchWave()
    {
        return _spawner.StartSpawning(_wave.EnemyCount, _wave.EnemySpawnInterval);
    }
}