using UnityEngine;

namespace Shmup1941
{
    [CreateAssetMenu(fileName = "TripleShot", menuName = "Shmup1941/WeaponStrategy/TripleShot")]
    public class TripleShot : WeaponStrategy
    {
        [SerializeField] private float _spreadAngle = 15;
        
        public override void Fire(Transform firePoint, LayerMask layerMask)
        {
            for (int i = 0; i < 3; i++)
            {
                var projecttile = Instantiate(_projecttilePrefab, firePoint.position, firePoint.rotation);
                projecttile.transform.SetParent(firePoint);
                projecttile.transform.Rotate(0, _spreadAngle * (i - 1), 0);
                projecttile.layer = layerMask;
            
                var projecttileComponent = projecttile.GetComponent<Projectile>();
                projecttileComponent.SetSpeed(_projecttileSpeed);
            
                Destroy(projecttile, _projecttileLifetime);
            }
        }
    }
}