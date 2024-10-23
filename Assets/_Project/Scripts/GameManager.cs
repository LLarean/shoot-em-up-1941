using Eflatun.SceneReference;
using UnityEngine;

namespace Shmup1941
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private SceneReference _targetScene;
        [SerializeField] private PlayerPlane _playerPlane;
        [SerializeField] private GameObject _gameOverUI;

        private int _score;
        private float _restartTimer = 3;
        
        public int Score => _score;
        public bool IsGameOver => _playerPlane.GetHealthNormilized() <= 0 || _playerPlane.GetFuelNormolized() <= 0;
        public PlayerPlane PlayerPlane => _playerPlane;

        public void AddScore(int amount) => _score += amount;
        
        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (IsGameOver == false) return;
                
            _restartTimer -= Time.deltaTime;

            if (_gameOverUI.activeSelf == false)
            {
                _gameOverUI.SetActive(true);
            }
            
            if (_restartTimer <= 0)
            {
                Loader.Load(_targetScene);
            }

        }
    }
}