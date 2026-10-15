using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    private const float Delay = 0.5f;

    [SerializeField] private Enemy _prefab;

    [SerializeField] private Transform[] _pointsSpawn;

    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<Enemy> _pool;

    private WaitForSeconds _wait = new WaitForSeconds(Delay);

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
        createFunc: () => {
            Enemy enemy = Instantiate(_prefab);
            return enemy;
        },
        actionOnGet: (enemy) => PrepareObject(enemy),
        actionOnRelease: (enemy) => enemy.gameObject.SetActive(false),
        actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _poolMaxSize);
    }

    private void Start()
    {
        _pool.Get();
    }

    private void PrepareObject(Enemy enemy)
    {
        var randomPoint = Random.Range(0, _pointsSpawn.Length);
        var position = _pointsSpawn[randomPoint].position;

        enemy.ChangeStates(position);
        enemy.gameObject.SetActive(true);
    }
}