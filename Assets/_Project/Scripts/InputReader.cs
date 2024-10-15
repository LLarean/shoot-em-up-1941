using UnityEngine;
using UnityEngine.InputSystem;

namespace Shmup1941
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        
        private InputAction _moveAction;

        public Vector2 Move => _moveAction.ReadValue<Vector2>();

        private void Start()
        {
            _moveAction = _playerInput.actions[GlobalStrings.Move];
        }
    }
}