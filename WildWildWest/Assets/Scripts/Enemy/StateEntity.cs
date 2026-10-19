using UnityEngine;

public class StateEntity : MonoBehaviour
{
    [SerializeField] private TargetFollower _follower;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private AttackRangeChecker _rangeChecker;

    private EnemyState _currentState;

    private void OnEnable()
    {
        _rangeChecker.OnTargetEnteredRange += LaunchAttack;
        _rangeChecker.OnTargetExitedRange += LaunchMove;

        LaunchMove();
    }

    private void OnDisable()
    {
        _rangeChecker.OnTargetEnteredRange -= LaunchAttack;
        _rangeChecker.OnTargetExitedRange -= LaunchMove;
    }

    private void Update()
    {
        switch(_currentState)
        {
            case EnemyState.follow:
                _follower.Follow();
                break;

            case EnemyState.attack:
                _attacker.Attack();
                break;
        }
    }

    private void LaunchMove()
    {
        _currentState = EnemyState.follow;
        _follower.Resume();
    }

    private void LaunchAttack()
    {
        _currentState = EnemyState.attack;
        _follower.Stop();
    }
}