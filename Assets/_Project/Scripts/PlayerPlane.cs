using UnityEngine;

namespace Shmup1941
{
    public class PlayerPlane : Plane
    {
        [SerializeField] private float _maximumFuel;
        [SerializeField] private float _fuelConsumptionRate;
        
        private float _currentFuel;
        
        public float GetFuelNormolized() => _currentFuel / _maximumFuel;

        public void AddFuel(int amount)
        {
            _currentFuel += amount;

            if (_currentFuel > _maximumFuel)
            {
                _currentFuel = _maximumFuel;
            }
        }

        protected override void Die()
        {
            throw new System.NotImplementedException();
        }


        private void Start() => _currentFuel = _maximumFuel;
        
        private void Update()
        {
            _currentFuel -= Time.deltaTime * _fuelConsumptionRate;
        }
    }
}