using _Project.Scripts.Scenes;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace _Project.Scripts.Bootstrap
{
    public class BootstrapInititalizer : MonoBehaviour
    {
        private ScenesProvider _scenesProvider;
        private LoadSceneService _loadSceneService;

        [Inject]
        private void Costruct(ScenesProvider scenesProvider, LoadSceneService loadSceneService)
        {
            _scenesProvider = scenesProvider;
            _loadSceneService = loadSceneService;
        }

        private async void Start()
        {
            await Addressables.InitializeAsync();

            await _scenesProvider.LoadSceneConfigsAsync();

            await _loadSceneService.LoadSceneAsync(SceneDesignation.MainMenu);
        }
    }
}