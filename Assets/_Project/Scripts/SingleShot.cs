using UnityEngine;

namespace Shmup1941
{
    [CreateAssetMenu(fileName = "SingleShot", menuName = "Shmup1941/WeaponStrategy/SingleShot")]
    public class SingleShot : WeaponStrategy
    {
        public override void Fire(Transform firePoint, LayerMask layerMask)
        {
            var projecttile = Instantiate(_projecttilePrefab, firePoint.position, firePoint.rotation);
            projecttile.transform.SetParent(firePoint);
            projecttile.layer = layerMask;
            
            var projecttileComponent = projecttile.GetComponent<Projectile>();
            projecttileComponent.SetSpeed(_projecttileSpeed);
            
            Destroy(projecttile, _projecttileLifetime);
        }
    }
}