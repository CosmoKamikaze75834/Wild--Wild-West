using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyStateMachine : MonoBehaviour
{
    private IEnemyState _currentState;

    private Dictionary<EnemyState, IEnemyState> _states;

    private void OnDisable()
    {
        _currentState = null;
    }

    private void Update()
    {
        if (_currentState != null)
            _currentState.Update();
    }

    public void ChangeState(EnemyState state)
    {
        IEnemyState enemyState = _states[state];

        if (_currentState == enemyState)
            return;

        _currentState = enemyState;
        _currentState.Enter();
    }

    [Inject]
    private void Construct(EnemyStateMachineFactory enemyStateMachineFactory)
    {
        _states = enemyStateMachineFactory.Create();
    }
}