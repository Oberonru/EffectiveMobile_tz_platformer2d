using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Player.Components
{
    public class PlayerController : MonoBehaviour
    {

        private PlayerInput _playerInput;
        private InputAction _moveAction;
        private InputAction _jumpAction;
        private InputAction _attackAction;

        private void Awake()
        {
            if (_playerInput == null) _playerInput = GetComponent<PlayerInput>();
            
            _moveAction = _playerInput.actions["Move"];
            _jumpAction = _playerInput.actions["Jump"];
            _attackAction = _playerInput.actions["Attack"];
        }
        
        private void Update()
        {
            var move =  _moveAction.ReadValue<Vector2>();

            if (_jumpAction.triggered)
            {
                print("Jump");
            }

            if (_attackAction.triggered)
            {
                print("Attack");
            }
        }
    }
}