using UnityEngine;
using UnityEngine.Splines;

namespace Shmup1941
{
    public class EnemyFactory
    {
        public GameObject CreateEnemy(EnemyType enemyType, SplineContainer splineContainer)
        {
            EnemyBuilder enemyBuilder = new EnemyBuilder()
                .SerBasePrefab(enemyType.EnemyPrefab)
                .SerSplineContainer(splineContainer)
                .SerSpeed(enemyType.Speed);

            return enemyBuilder.Build();
        }
    }
}