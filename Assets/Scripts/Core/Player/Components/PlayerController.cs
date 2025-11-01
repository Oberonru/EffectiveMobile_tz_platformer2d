using System;
using Core.Configs.Player;
using UniRx;
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

        public IObservable<bool> OnRun => _onRun;
        private Subject<bool> _onRun = new();
        public IObservable<Unit> OnJump => _onJump;
        private Subject<Unit> _onJump = new();
        public IObservable<Unit> OnAttack => _onAttack;
        private Subject<Unit> _onAttack = new();

        private PlayerInput _playerInput;
        private InputAction _moveAction;
        private InputAction _jumpAction;
        private InputAction _attackAction;

        private Rigidbody2D _rigidbody;
        private Vector2 _moveInput;
        private bool _isJumping;
        private bool _isPrevRunning;

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
            
            var isRunning = Mathf.Abs(_moveInput.x) > 0.1f && IsGrounded();
            if (isRunning != _isPrevRunning)
            {
                _onRun?.OnNext(isRunning);
                _isPrevRunning = isRunning;
            }

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
            else
            {
                _isJumping = false;
            }
        }

        private void Move()
        {
            RotateToInput();

            var velocity = _rigidbody.velocity;
            velocity.x = _moveInput.x * _config.Speed;
            _rigidbody.velocity = velocity;
        }

        private void Jump()
        {
            var velocity = _rigidbody.velocity;
            velocity.y = _config.JumpForce;
            _rigidbody.velocity = velocity;
            
            _onJump?.OnNext(Unit.Default);
        }

        private void RotateToInput()
        {
            if (_moveInput.x > 0.01f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y,
                    transform.localScale.z);
            }
            else if (_moveInput.x < -0.01f)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y,
                    transform.localScale.z);
            }
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
            _onAttack?.OnNext(Unit.Default);
        }
    }
}