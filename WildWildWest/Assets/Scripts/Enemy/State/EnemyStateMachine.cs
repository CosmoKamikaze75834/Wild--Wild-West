using UnityEngine;
using Zenject;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private AttackRangeChecker _rangeChecker;

    private IEnemyState _currentState;
    private IEnemyState _moveState;
    private IEnemyState _attackState;

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

        _currentState = null;
    }

    private void Update()
    {
        if (_currentState != null)
            _currentState.Update();
    }

    private void LaunchMove()
    {
        ChangeState(_moveState);
    }

    private void LaunchAttack()
    {
        ChangeState(_attackState);
    }

    private void ChangeState(IEnemyState newState)
    {
        if (_currentState == newState)
            return;

        _currentState = newState;
        _currentState.Enter();
    }

    [Inject]
    private void Construct(EnemyMoveState enemyMoveState, EnemyAttackState enemyAttackState)
    {
        _moveState = enemyMoveState;
        _attackState = enemyAttackState;
    }
}