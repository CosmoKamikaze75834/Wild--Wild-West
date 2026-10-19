using Zenject;

public class EnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IAnimationEnemy>().To<EnemyAnimationHandler>().FromComponentInHierarchy().AsSingle();

        Container.Bind<AttackRangeChecker>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Attacker>().FromComponentInHierarchy().AsSingle();
        Container.Bind<TargetFollower>().FromComponentInHierarchy().AsSingle();

        Container.Bind<EnemyMoveState>().AsSingle();
        Container.Bind<EnemyAttackState>().AsSingle();

    }
}