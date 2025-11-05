using System;
using Core.Configs.Audio;
using Core.Configs.Player;
using Core.Handlers;
using Core.Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Core.Player.Components
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour, IStateComponent
    {
        [Inject] private IAudioHandler _handler;
        [Inject] private AudioClipsConfig _clipsConfig;
        [Inject] private PlayerConfig _config;
        public Rigidbody2D Rigidbody => _rigidbody;
        [SerializeField] private Transform _groundCheck;

        public IObservable<Unit> JumpStream => _jumpStream;
        private readonly Subject<Unit> _jumpStream = new();

        public IObservable<Unit> AttackStream => _attackStream;
        private readonly Subject<Unit> _attackStream = new();

        private Rigidbody2D _rigidbody;
        private Vector2 _moveInput;
        private bool _isJumping;

        public Vector2 MoveInput => _moveInput;
        public float VelocityX => _rigidbody.velocity.x;
        public float VelocityY => _rigidbody.velocity.y;

        private void Awake()
        {
            if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody2D>();
        }

        private bool IsGrounded()
        {
            var hit = Physics2D.Raycast(
                _groundCheck.position,
                Vector2.down,
                _config.GroundCheckDistance,
                ~0
            );

            return hit.collider != null &&
                   !hit.collider.isTrigger &&
                   hit.normal.y >= _config.GroundNormalThreshold;
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

        private void RotateToInput()
        {
            if (_moveInput.x > 0.01f)
            {
                transform.localScale = new Vector3(
                    Mathf.Abs(transform.localScale.x),
                    transform.localScale.y,
                    transform.localScale.z
                );
            }
            else if (_moveInput.x < -0.01f)
            {
                transform.localScale = new Vector3(
                    -Mathf.Abs(transform.localScale.x),
                    transform.localScale.y,
                    transform.localScale.z
                );
            }
        }

        public void OnMove(InputValue value)
        {
            _moveInput = value.Get<Vector2>();
        }

        public void OnJump(InputValue value)
        {
            if (IsGrounded())
                _isJumping = true;
        }

        public void OnAttack(InputValue value)
        {
            if (IsGrounded())
                Attack();
        }

        public void Enable() => enabled = true;
        public void Disable() => enabled = false;

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

            _handler.PlaySfx(_clipsConfig.Jumps);
            _jumpStream?.OnNext(Unit.Default);
        }

        private void Attack()
        {
            _handler.PlaySfx(_clipsConfig.Attack);
            _attackStream?.OnNext(Unit.Default);
        }
    }
}