using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.AssetManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace _Project.Scripts.Scenes
{
    public sealed class ScenesProvider
    {
        private AsyncOperationHandle<IList<SceneConfig>> _handle;

        private readonly Dictionary<SceneDesignation, SceneConfig> _sceneConfigs = new();

        public async UniTask LoadSceneConfigsAsync()
        {
            _handle = Addressables.LoadAssetsAsync<SceneConfig>(AddressableKeys.ConfigsLabel);

            await _handle.ToUniTask();

            if (_handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError("[SceneConfigProvider] Failed to load scene configs");
                return;
            }

            var configs = new List<SceneConfig>(_handle.Result);

            foreach (var config in configs)
            {
                _sceneConfigs.Add(config.Designation, config);
            }
        }

        public AssetReference GetSceneByDesignation(SceneDesignation sceneDesignation)
        {
            if (_sceneConfigs.TryGetValue(sceneDesignation, out var sceneConfig))
            {
                return sceneConfig.SceneAsset;
            }

            return null;
        }

        public void Release()
        {
            if (_handle.IsValid())
            {
                Addressables.Release(_handle);
            }
        }
    }
}