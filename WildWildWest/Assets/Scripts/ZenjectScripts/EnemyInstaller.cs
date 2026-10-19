using Zenject;

public class EnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IAnimationEnemy>().To<EnemyAnimationHandler>().FromComponentInHierarchy().AsSingle();
    }
}
