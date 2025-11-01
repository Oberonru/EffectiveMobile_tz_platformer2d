using Core.Configs.Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Core.Player.Components
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [Inject] private PlayerConfig _config;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundLayer;

        private PlayerInput _playerInput;
        private InputAction _moveAction;
        private InputAction _jumpAction;
        private InputAction _attackAction;

        private Rigidbody2D _rigidbody;
        private Vector2 _moveInput;
        private bool _isJumping;

        private void Awake()
        {
            if (_playerInput == null) _playerInput = GetComponent<PlayerInput>();
            if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody2D>();

            _moveAction = _playerInput.actions["Move"];
            _jumpAction = _playerInput.actions["Jump"];
            _attackAction = _playerInput.actions["Attack"];
        }

        private void Update()
        {
            _moveInput = _moveAction.ReadValue<Vector2>();

            if (_jumpAction.triggered && IsGrounded())
            {
                _isJumping = true;
            }

            if (_attackAction.triggered)
            {
                Attack();
            }
        }

        private void FixedUpdate()
        {
            Move();

            if (_isJumping && IsGrounded())
            {
                Jump();
                _isJumping = false;
            }
        }

        private void Move()
        {
            var rbVelocity = _rigidbody.velocity;
            rbVelocity.x = _moveInput.x * _config.Speed;
            _rigidbody.velocity = rbVelocity;
        }

        private void Jump()
        {
            var velocity = _rigidbody.velocity;
            velocity.y = _config.JumpForce;
            _rigidbody.velocity = velocity;
        }

        private bool IsGrounded()
        {
            var hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, _config.GroundCheckDistance, ~0);

            return hit.collider != null && !hit.collider.isTrigger &&
                   hit.normal.y >= _config.GroundNormalThreshold;
        }

        private void Attack()
        {
            print("Attack");
        }
    }
}