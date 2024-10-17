using UnityEngine;
using Utilities;

namespace Shmup1941
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected WeaponStrategy _weaponaStrategy;
        [SerializeField] protected Transform _firePoint;
        [SerializeField, Layer] protected int _layer;
        
        
        public void SetWeaponStrategy(WeaponStrategy weaponStrategy)
        {
            _weaponaStrategy = weaponStrategy;
            _weaponaStrategy.Initialize();
        }

        private void OnValidate() => _layer = gameObject.layer;

        private void Start() => _weaponaStrategy.Initialize();
        
        
    }
}