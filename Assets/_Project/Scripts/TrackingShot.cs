using UnityEngine;
using Utilities;

namespace Shmup1941
{
    [CreateAssetMenu(fileName = "TrackingShot", menuName = "Shmup1941/WeaponStrategy/TrackingShot")]
    public class TrackingShot : WeaponStrategy
    {
        [SerializeField] private float _trackingSpeed = 1f;
        
        private Transform _target;
        
        public override void Fire(Transform firePoint, LayerMask layerMask)
        {
            var projecttile = Instantiate(_projecttilePrefab, firePoint.position, firePoint.rotation);
            projecttile.transform.SetParent(firePoint);
            projecttile.layer = layerMask;
            
            var projecttileComponent = projecttile.GetComponent<Projectile>();
            projecttileComponent.SetSpeed(_projecttileSpeed);
            projecttile.GetComponent<Projectile>().Callback = () =>
            {
                Vector3 direction = (_target.position - projecttile.transform.position).With(z:firePoint.position.z).normalized;
                
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.forward);
                projecttile.transform.rotation = Quaternion.Slerp(projecttile.transform.rotation, rotation, Time.deltaTime * _trackingSpeed);
                
            };
            
            Destroy(projecttile, _projecttileLifetime);
        }
    }
}