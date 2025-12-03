using _Project.Scripts.Scenes;
using Zenject;

namespace _Project.Scripts.Root
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ScenesProvider>().AsSingle();
            Container.Bind<LoadSceneService>().AsSingle();
        }
    }
}