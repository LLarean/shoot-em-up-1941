using UnityEngine;

namespace Shmup1941
{
    public abstract class WeaponStrategy : ScriptableObject
    {
        [SerializeField] protected float _projecttileSpeed = 10;
        [SerializeField] protected float _projecttileLifetime = 4;
        [SerializeField] protected GameObject _projecttilePrefab;

        [SerializeField] private float _fireRate = .5f;
        [SerializeField] private int _damage = 10;
        
        public int Damage => _damage;
        public float FireRate => _fireRate;

        public virtual void Initialize()
        {
            
        }
        
        public abstract void Fire(Transform firePoint, LayerMask layerMask);
    }
}