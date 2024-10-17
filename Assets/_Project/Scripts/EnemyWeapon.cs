using UnityEngine;

namespace Shmup1941
{
    public class EnemyWeapon : Weapon
    {
        private float _fireTimer;

        private void Update()
        {
            _fireTimer += Time.deltaTime;

            if (_fireTimer >= _weaponaStrategy.FireRate)
            {
                _weaponaStrategy.Fire(_firePoint, _layer);
                _fireTimer = 0;
            }
        }
    }
}