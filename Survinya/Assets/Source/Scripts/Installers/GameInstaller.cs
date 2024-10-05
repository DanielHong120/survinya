using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InputReader>().FromComponentInHierarchy().AsSingle();

        Container.Bind<PlayerStateManager>().FromComponentInHierarchy().AsSingle();

        Container.Bind<PlayerStateView>().FromComponentInHierarchy().AsSingle();
    }
}