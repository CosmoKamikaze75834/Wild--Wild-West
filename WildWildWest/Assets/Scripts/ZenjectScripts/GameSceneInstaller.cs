using Zenject;


public class GameSceneInstaller : MonoInstaller
{
    //дл€ объ€влени€ правила предоставлени€ зависимостей
    public override void InstallBindings()
    {
        Container.Bind<IMotionControl>().To<InputSystem>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InputMove>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerInput>().AsSingle();
    }
}