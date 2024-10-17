using UnityEngine;

namespace Shmup1941
{
    public class PlayerWeapon : Weapon
    {
        private InputReader _inputReader;
        private float _fireTimer;

        private void Awake() => _inputReader = GetComponent<InputReader>();
        
        private void Update()
        {
            _fireTimer += Time.deltaTime;

            if (_inputReader.Fire && _fireTimer >= _weaponaStrategy.FireRate)
            {
                _weaponaStrategy.Fire(_firePoint, _layer);
                _fireTimer = 0;
            }
        }
    }
}