using UnityEngine;
using Zenject;

public class StateEntity : MonoBehaviour
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

        if (_currentState != null)
            _currentState.Exit();

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

    //переключаемые состо€ни€
    private void ChangeState(IEnemyState newState)
    {
        //чтобы не переключатьс€ повторно
        if (_currentState == newState)
            return;

        _currentState?.Exit();//завершаем предыдущее состо€ние если оно существует
        _currentState = newState;//устанавливаем новое состо€ние
        _currentState.Enter();//запускаем действие при входе в него
    }

    [Inject]
    private void Construct(EnemyMoveState enemyMoveState, EnemyAttackState enemyAttackState)
    {
        _moveState = enemyMoveState;
        _attackState = enemyAttackState;
    }
}