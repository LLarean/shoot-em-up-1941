using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using Utilities;

namespace Shmup1941
{
    public class EnemyBuilder
    {
        private GameObject _enemyPrefab;
        private SplineContainer _splineContainer;
        private float _speed;

        public EnemyBuilder SerBasePrefab(GameObject prefab)
        {
            _enemyPrefab = prefab;
            return this;
        }

        public EnemyBuilder SerSplineContainer(SplineContainer splineContainer)
        {
            _splineContainer = splineContainer;
            return this;
        }

        public EnemyBuilder SerSpeed(float speed)
        {
            _speed = speed;
            return this;
        }

        public GameObject Build()
        {
            GameObject instance = Object.Instantiate(_enemyPrefab);
            
            SplineAnimate splineAnimate = instance.GetOrAddComponent<SplineAnimate>();
            splineAnimate.Container = _splineContainer;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineAnimate.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineAnimate.AlignAxis.YAxis;
            splineAnimate.MaxSpeed = _speed;

            instance.transform.position = _splineContainer.EvaluatePosition(0f);

            return instance;
        }
    }
}