using System.Collections.Generic;
using Core.Enemies.Configs;
using Core.Player;
using UnityEngine;
using Zenject;

namespace Core.Enemies.Behaviors
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class PatrolBehavior : MonoBehaviour
    {
        [Inject] private PatrolBehaviourConfig _config;

        [SerializeField] private Transform _forwardCheck;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private bool _useKinematicMovement;
        [SerializeField] private bool _isRightDirection;

        private Rigidbody2D _rb;
        private Collider2D _col;
        private Vector2 _startPosition;
        private int _direction = 1;
        private float _lastTurnTime;

        private readonly List<RaycastHit2D> _hitsBuffer = new(8);

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _col = GetComponent<Collider2D>();

            if (_useKinematicMovement)
            {
                _rb.bodyType = RigidbodyType2D.Kinematic;
                _rb.gravityScale = 0f;
            }
            else
            {
                _rb.bodyType = RigidbodyType2D.Dynamic;
                _rb.gravityScale = 1f;
                _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }

        private void Start()
        {
            SetMoveDirection();
            _startPosition = transform.position;
        }

        private void Update()
        {
            if (_useKinematicMovement)
            {
                NavigateKinematic();
            }
            else
            {
                NavigatePhysics();
            }

            CheckForwardWall();
            CheckGroundAhead();
        }

        private void NavigateKinematic()
        {
            transform.Translate(Vector2.right * (_direction * _config.Speed * Time.deltaTime));

            var offset = transform.position.x - _startPosition.x;
            if (Mathf.Abs(offset) >= _config.MovementDistance)
            {
                ReverseDirection();
                var clampedX = Mathf.Clamp(transform.position.x,
                    _startPosition.x - _config.MovementDistance,
                    _startPosition.x + _config.MovementDistance);
                transform.position = new Vector2(clampedX, transform.position.y);
            }
        }

        private void NavigatePhysics()
        {
            _rb.velocity = new Vector2(_direction * _config.Speed, _rb.velocity.y);

            var offset = transform.position.x - _startPosition.x;
            if (Mathf.Abs(offset) >= _config.MovementDistance)
            {
                ReverseDirection();
            }
        }

        private void CheckForwardWall()
        {
            if (_forwardCheck == null) return;

            _hitsBuffer.Clear();
            Vector2 dir = Vector2.right * _direction;
            var distance = _config.ForwardRayDistance;

            var filter = new ContactFilter2D
            {
                useTriggers = false,
                useLayerMask = false
            };

            int hits = _rb.Cast(dir, filter, _hitsBuffer, distance);

            if (hits > 0)
            {
                foreach (var hit in _hitsBuffer)
                {
                    if (hit.collider == null) continue;
                    if (hit.collider == _col) continue;
                    if (hit.collider.gameObject == gameObject) continue;
                    if (hit.collider.TryGetComponent<PlayerInstance>(out _)) continue;
                    if (Vector2.Dot(hit.normal, dir) < -0.5f)
                    {
                        ReverseDirection();
                        break;
                    }
                }
            }
        }

        private void CheckGroundAhead()
        {
            if (_groundCheck == null) return;

            RaycastHit2D hit = Physics2D.Raycast(
                _groundCheck.position,
                Vector2.down,
                _config.DownRayDistance,
                Physics2D.DefaultRaycastLayers
            );

            if (hit.collider != null && hit.collider != _col)
            {
                return;
            }

            ReverseDirection();
        }

        private void ReverseDirection()
        {
            if (Time.time < _lastTurnTime + _config.TurnCooldown) return;

            _direction *= -1;

            var scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * _direction;
            transform.localScale = scale;

            _lastTurnTime = Time.time;
        }

        private void SetMoveDirection()
        {
            _direction = _isRightDirection ? 1 : -1;

            var scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * _direction;
            transform.localScale = scale;
        }

        private void OnDrawGizmos()
        {
            if (_config == null) return;

            Gizmos.color = Color.red;
            if (_forwardCheck != null)
            {
                Gizmos.DrawLine(_forwardCheck.position,
                    _forwardCheck.position + Vector3.right * _direction * _config.ForwardRayDistance);
            }

            Gizmos.color = Color.green;
            if (_groundCheck != null)
            {
                Gizmos.DrawLine(_groundCheck.position,
                    _groundCheck.position + Vector3.down * _config.DownRayDistance);
            }
        }
    }
}