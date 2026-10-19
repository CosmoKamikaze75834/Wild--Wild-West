using UnityEngine;
using Zenject;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private EnemyNavigation _navigation;

    private Player _player;

    public void Follow()
    {
        if (_player == null)
            return;

        _navigation.SetDestination(_player.transform.position);
    }

    public void Stop() =>
        _navigation.Stop();

    public void Resume() =>
        _navigation.Resume();

    [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }
}