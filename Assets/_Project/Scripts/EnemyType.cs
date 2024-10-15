using UnityEngine;

namespace Shmup1941
{
    [CreateAssetMenu(fileName = "EnemyType", menuName = "Shmup1941/EnemyType", order = 0)]
    public class EnemyType : ScriptableObject
    {
        public GameObject EnemyPrefab;
        public float Speed;
    }
}