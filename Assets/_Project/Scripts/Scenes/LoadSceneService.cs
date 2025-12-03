using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace _Project.Scripts.Scenes
{
    public class LoadSceneService
    {
        private AsyncOperationHandle<SceneInstance> _currentHandle;

        private ScenesProvider _scenesProvider;

        public LoadSceneService(ScenesProvider scenesProvider)
        {
            _scenesProvider = scenesProvider;
        }

        public async UniTask LoadSceneAsync(SceneDesignation sceneDesignation)
        {
            var sceneAssetReference = _scenesProvider.GetSceneByDesignation(sceneDesignation);

            if (_currentHandle.IsValid())
            {
                await Addressables.UnloadSceneAsync(_currentHandle).ToUniTask();
                _currentHandle = default;
            }

            var handle = Addressables.LoadSceneAsync(sceneAssetReference);
            _currentHandle = handle;

            // Пока не завершено — просто обновляем прогресс
            while (!handle.IsDone)
            {
                // onProgress?.Invoke(handle.PercentComplete);
                await UniTask.Yield();
            }

            // onProgress?.Invoke(1f);
        }
    }
}