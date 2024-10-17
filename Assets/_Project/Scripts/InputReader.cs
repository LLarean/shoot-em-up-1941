using UnityEngine;
using UnityEngine.InputSystem;

namespace Shmup1941
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        
        private InputAction _moveAction;
        private InputAction _fireAction;

        public Vector2 Move => _moveAction.ReadValue<Vector2>();
        public bool Fire => _fireAction.ReadValue<float>() > 0f;

        private void Start()
        {
            _moveAction = _playerInput.actions[GlobalStrings.Move];
            _fireAction = _playerInput.actions[GlobalStrings.Fire];
        }
    }
}