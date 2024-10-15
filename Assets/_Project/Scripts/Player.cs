using UnityEngine;

namespace Shmup1941
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed = 5;
        [SerializeField] private GameObject _model;
        [SerializeField] private InputReader _input;
        [SerializeField] private float _smoothness = .1f;
        [SerializeField] private float _leanAngle = 15;
        [SerializeField] private float _leanSpeed = 5;
        [Space]
        [SerializeField] private Transform _cameraFollow;
        [SerializeField] private float _minimumX = -8;
        [SerializeField] private float _maximumX = 8;
        [SerializeField] private float _minimumY = -4;
        [SerializeField] private float _maximumY = 4;
        
        private Vector3 _currentVelocity;
        private Vector3 _targetPosition;

        private void Update()
        {
            _targetPosition += new Vector3(_input.Move.x, _input.Move.y) * (_speed * Time.deltaTime);

            var minPlayerX = _cameraFollow.position.x + _minimumX;
            var maxPlayerX = _cameraFollow.position.x + _maximumX;
            var minPlayerY = _cameraFollow.position.y + _minimumY;
            var maxPlayerY = _cameraFollow.position.y + _maximumY;
            
            _targetPosition.x = Mathf.Clamp(_targetPosition.x, minPlayerX, maxPlayerX);
            _targetPosition.y = Mathf.Clamp(_targetPosition.y, minPlayerY, maxPlayerY);
            
            transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _currentVelocity, _smoothness);
            
            var targetRotationAngle = -_input.Move.x * _leanAngle;
            
            var currentRotationY = transform.localEulerAngles.y;
            var newRotationY = Mathf.LerpAngle(currentRotationY, targetRotationAngle, _leanSpeed * Time.deltaTime);
            
            transform.localEulerAngles = new Vector3(0, newRotationY, 0);
        }
    }
}