using Zenject;
using Zenject.SpaceFighter;


public class GameSceneInstaller : MonoInstaller
{
    //дл€ объ€влени€ правила предоставлени€ зависимостей
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<InputSystem>().FromComponentInHierarchy().AsSingle();

        Container.Bind<IAnimationPlayer>().To<PlayerAnimationHandler>().FromComponentInHierarchy().AsSingle();

        Container.Bind<InputMove>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InputRotation>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InputJump>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InputRun>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InputAttack>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InputScroll>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IDamageable>().FromMethod(context => context.Container.Resolve<Player>().GetComponent<Health>()).AsCached();

        Container.Bind<PlayerInput>().AsSingle();

        Container.Bind<CameraRotation>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Movement>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Jumper>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
    }
}