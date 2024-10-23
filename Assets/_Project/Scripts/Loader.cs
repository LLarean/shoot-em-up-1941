using System.Collections.Generic;
using Eflatun.SceneReference;
using MEC;
using UnityEngine.SceneManagement;

namespace Shmup1941
{
    public static class Loader
    {
        private static SceneReference _targetScene;
        private static string _loadingSceneName = "Loading";

        public static void Load(SceneReference targetScene)
        {
            _targetScene = targetScene;
            SceneManager.LoadScene(_loadingSceneName);
            Timing.RunCoroutine(LoadTargetScene());
        }

        private static IEnumerator<float> LoadTargetScene()
        {
            yield return Timing.WaitForOneFrame;
            SceneManager.LoadScene(_targetScene.Name);
        }
    }
}