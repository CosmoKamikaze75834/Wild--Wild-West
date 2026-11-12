using System.Collections.Generic;
using Zenject;

public class EnemyStateMachineFactory
{
    private IEnemyState _enemyMoveState;
    private IEnemyState _enemyAttackState;

    public Dictionary<EnemyState, IEnemyState> Create()
    {
        Dictionary<EnemyState, IEnemyState> states = new Dictionary<EnemyState, IEnemyState>();

        states.Add(EnemyState.Move, _enemyMoveState);
        states.Add(EnemyState.Attack, _enemyAttackState);

        return states;
    }

    [Inject]
    private void Construct(EnemyMoveState enemyMoveState, EnemyAttackState enemyAttackState)
    {
        _enemyMoveState = enemyMoveState;
        _enemyAttackState = enemyAttackState;
    }
}