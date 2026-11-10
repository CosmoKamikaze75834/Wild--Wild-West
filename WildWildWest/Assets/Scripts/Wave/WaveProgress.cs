public class WaveProgress
{
    private const int InitialEnemyCount = 0;

    private int _spawnedEnemyCount;
    private int _deadEnemyCount;

    private bool _isSpawningCompleted;
    private bool _isBossScheduled;

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
        _spawnedEnemyCount = InitialEnemyCount;
        _deadEnemyCount = InitialEnemyCount;

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