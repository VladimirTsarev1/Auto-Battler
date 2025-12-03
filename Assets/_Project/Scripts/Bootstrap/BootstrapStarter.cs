using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Bootstrap
{
    public static class BootstrapStarter
    {
        private const string SceneName = "0_Bootstrap";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            if (SceneManager.GetActiveScene().name != SceneName)
            {
                SceneManager.LoadScene(SceneName);
            }
        }
    }
}