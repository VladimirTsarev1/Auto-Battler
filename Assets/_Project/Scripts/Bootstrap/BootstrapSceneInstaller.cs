using Zenject;

namespace _Project.Scripts.Bootstrap
{
    public class BootstrapSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BootstrapInititalizer>().AsSingle();
        }
    }
}