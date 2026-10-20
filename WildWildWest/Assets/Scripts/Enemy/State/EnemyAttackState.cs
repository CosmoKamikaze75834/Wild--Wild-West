public class EnemyAttackState : IEnemyState
{
    private readonly Attacker _attacker;
    private readonly TargetFollower _targetFollower;

    public EnemyAttackState(Attacker attacker, TargetFollower targetFollower)
    {
        _attacker = attacker;
        _targetFollower = targetFollower;
    }

    public void Enter()
    {
        _targetFollower.Stop();
    }

    public void Exit()
    {

    }

    public void Update()
    {
        _attacker.Attack();
    }
}