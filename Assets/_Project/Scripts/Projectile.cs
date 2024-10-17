using System;
using UnityEngine;

namespace Shmup1941
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private GameObject _muzzlePrefab;
        [SerializeField] private GameObject _hitPrefab;

        private Transform _parent;

        public Action Callback;
        
        public void SetSpeed(float speed) => _speed = speed;
        
        public void SetParent(Transform parent) => _parent = parent;
        
        private void Start()
        {
            if (_muzzlePrefab != null)
            {
                var muzzleVFX = Instantiate(_muzzlePrefab, transform.position, Quaternion.identity);
                muzzleVFX.transform.forward = gameObject.transform.forward;
                muzzleVFX.transform.SetParent(_parent);
                
                DestroyParticles(muzzleVFX);
            }
        }

        private void Update()
        {
            transform.SetParent(null);
            transform.position += transform.forward * (_speed * Time.deltaTime);
            Callback?.Invoke();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_hitPrefab != null)
            {
                ContactPoint contactPoint= other.contacts[0];
                var hitVFX = Instantiate(_hitPrefab, contactPoint.point, Quaternion.identity);
                DestroyParticles(hitVFX);
            }
            
            Destroy(gameObject);
        }

        private void DestroyParticles(GameObject vfx)
        {
            var particles = vfx.GetComponent<ParticleSystem>();

            if (particles == null)
            {
                particles = vfx.GetComponentInChildren<ParticleSystem>();
            }
            
            Destroy(vfx, particles.main.duration);
        }
    }
}