using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Project.Scripts.Scenes
{
    [CreateAssetMenu(fileName = "SceneConfig", menuName = "ScriptableObjects/SceneConfig")]
    public class SceneConfig : ScriptableObject
    {
        [field: SerializeField] public SceneDesignation Designation { get; private set; }
        [field: SerializeField] public AssetReference SceneAsset { get; private set; }
    }
}