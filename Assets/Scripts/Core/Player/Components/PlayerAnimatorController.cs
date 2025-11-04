using UniRx;
using UnityEngine;

namespace Core.Player.Components
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimatorController : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] private PlayerInstance _player;

        private static readonly int JumpHash = Animator.StringToHash("Jump");
        private static readonly int SpeedHash = Animator.StringToHash("Speed");
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        private static readonly int DeathHash = Animator.StringToHash("IsDeath");

        private void OnEnable()
        {
            _player.PlayerController.OnJump.Subscribe(_ => _animator.SetTrigger(JumpHash)).AddTo(this);

            _player.PlayerController.OnAttack.Subscribe(_ => _animator.SetTrigger(AttackHash)).AddTo(this);

            _player.Health.OnDead.Subscribe(_ => { _animator.SetBool(DeathHash, true); }).AddTo(this);
        }

        private void OnValidate()
        {
            if (_animator == null) _animator = GetComponent<Animator>();
            if (_player == null) _player = GetComponent<PlayerInstance>();
        }

        private void Update()
        {
            if (CanRunAnimated())
                _animator.SetFloat(SpeedHash, Mathf.Abs(_player.PlayerController.VelocityX));
        }

        private bool CanRunAnimated()
        {
            return _player.PlayerController.IsGrounded() && _player.PlayerController.MoveInput != Vector2.zero &&
                   Mathf.Abs(_player.PlayerController.VelocityY) < -0.01f;
        }
    }
}