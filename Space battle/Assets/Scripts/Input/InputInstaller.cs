using SpaceBattle.Input;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInputProvider>().To<PlayerInputProvider>().AsSingle();
    }
}