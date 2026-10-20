using UnityEngine;

public class EnemyMoveState : IEnemyState
{
    private readonly TargetFollower _targetFollower;

    public EnemyMoveState(TargetFollower targetFollower)
    {
        _targetFollower = targetFollower;
    }

    public void Enter()
    {
        _targetFollower.Resume();
    }

    public void Exit()
    {

    }

    public void Update()
    {
        _targetFollower.Follow();
    }
}