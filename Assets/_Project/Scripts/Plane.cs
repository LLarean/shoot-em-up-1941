using UnityEngine;

namespace Shmup1941
{
    public abstract class Plane : MonoBehaviour
    {
        [SerializeField] private int _maximumHealth;
        
        private int _currentHealth;

        public void SetMaximumHealth(int maximumHealth) => _maximumHealth = maximumHealth;

        public float GetHealthNormilized() => _currentHealth / (float)_maximumHealth;

        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;

            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        public void AddHealth(int amount)
        {
            _currentHealth += amount;

            if (_currentHealth > _maximumHealth)
            {
                _currentHealth = _maximumHealth;
            }
        }

        private void Awake() => _currentHealth = _maximumHealth;

        protected abstract void Die();
    }
}