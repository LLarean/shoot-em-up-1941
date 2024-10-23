using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Shmup1941
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private SceneReference _targetScene;
        [SerializeField] private Button _play;
        [SerializeField] private Button _quit;

        private void Awake()
        {
            _play.onClick.AddListener(() => Loader.Load(_targetScene));
            _quit.onClick.AddListener(Helpers.QuitGame);
            Time.timeScale = 1f;
        }
    }
}