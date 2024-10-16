using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Shmup1941
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<SplineContainer> _splineContainers;
        [SerializeField] private List<EnemyType> _enemyTypes;
        [Space]
        [SerializeField] private int _maxEnemies = 6;
        [SerializeField] private float _spawnInterval = 2;
        
        private EnemyFactory _enemyFactory;
        private float _spawnTimer;
        private int _enemiesSpawned;

        private void OnValidate()
        {
            // _splineContainers = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        }

        private void Start() => _enemyFactory = new EnemyFactory();

        private void Update()
        {
            _spawnTimer += Time.deltaTime;

            if (_enemiesSpawned < _maxEnemies && _spawnTimer >= _spawnInterval)
            {
                SpawnEnemy();
                _spawnTimer = 0;
            }
        }

        private void SpawnEnemy()
        {
            EnemyType enemyType = _enemyTypes[Random.Range(0, _enemyTypes.Count)];
            SplineContainer splineContainer = _splineContainers[Random.Range(0, _splineContainers.Count)];
            
            _enemyFactory.CreateEnemy(enemyType, splineContainer);
            _enemiesSpawned++;
        }
    }
}