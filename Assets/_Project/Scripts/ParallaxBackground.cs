using UnityEngine;

namespace Shmup1941
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform[] _backgrounds;
        [Space]
        [SerializeField] private float _smoothing = 0.5f;
        [SerializeField] private float _multiplier = 10;
        
        private Vector3 _previousCameraPosition;

        private void Start() => _previousCameraPosition = _camera.position;

        private void Update()
        {
            for (int i = 0; i < _backgrounds.Length; i++)
            {
                var parallax = (_previousCameraPosition.y - _camera.position.y) * (i * _multiplier);
                var targetPosition  = _backgrounds[i].position.y + parallax;
                
                var backgroundTarget = new Vector3(_backgrounds[i].position.x, targetPosition, _backgrounds[i].position.z);
                _backgrounds[i].position = Vector3.Lerp(_backgrounds[i].position, backgroundTarget, _smoothing * Time.deltaTime);
            }
            
            _previousCameraPosition = _camera.position;
        }
    }
}