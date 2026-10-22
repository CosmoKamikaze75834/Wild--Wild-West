//Учёт погибших и появившихся врагов
public class WaveProgress
{
    private int _spawnedEnemyCount;
    private int _deadEnemyCount;

    private bool _isSpawningCompleted;//спавнер закончил создание обычных врагов?
    private bool _isBossScheduled;//запланировано ли появление босса?

    public void OnEnemySpawned(Enemy enemy)
    {
        _spawnedEnemyCount++;
    }

    public void OnEnemyDied(Enemy enemy)
    {
        _deadEnemyCount++;
    }

    public void Reset()
    {
        _spawnedEnemyCount = 0;
        _deadEnemyCount = 0;

        _isSpawningCompleted = false;
        _isBossScheduled = false;
    }

    public void MarkSpawningCompleted()
    {
        _isSpawningCompleted = true;
    }

    public bool TryScheduleBoss()
    {
        if (_isBossScheduled || !_isSpawningCompleted)
            return false;

        if (_spawnedEnemyCount != _deadEnemyCount)
            return false;

        _isBossScheduled = true;
        return true;
    }
}