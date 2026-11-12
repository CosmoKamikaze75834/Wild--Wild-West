using UnityEngine;

public class EnemyStateTransitionHandler : MonoBehaviour
{
    [SerializeField] private AttackRangeChecker _rangeChecker;
    [SerializeField] private EnemyStateMachine _enemyStateMachine;

    private void OnEnable()
    {
        _rangeChecker.TargetEnteredRange += LaunchAttack;
        _rangeChecker.TargetExitedRange += LaunchMove;

        LaunchMove();
    }

    private void OnDisable()
    {
        _rangeChecker.TargetEnteredRange -= LaunchAttack;
        _rangeChecker.TargetExitedRange -= LaunchMove;
    }

    private void LaunchMove()
    {
        _enemyStateMachine.ChangeState(EnemyState.Move);
    }

    private void LaunchAttack()
    {
        _enemyStateMachine.ChangeState(EnemyState.Attack);
    }
}