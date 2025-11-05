using UniRx;
using UnityEngine;

namespace Core.Player.Components
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerInstance _player;

        private static readonly int JumpHash = Animator.StringToHash("Jump");
        private static readonly int SpeedHash = Animator.StringToHash("Speed");
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        private static readonly int DeathHash = Animator.StringToHash("IsDeath");

        // Порог для фильтрации мелких дрожаний скорости
        private const float SpeedThreshold = 0.05f;

        private void OnEnable()
        {
            _player.PlayerController.JumpStream
                .Subscribe(_ => _animator.SetTrigger(JumpHash))
                .AddTo(this);

            _player.PlayerController.AttackStream
                .Subscribe(_ => _animator.SetTrigger(AttackHash))
                .AddTo(this);

            _player.Health.OnDead
                .Subscribe(_ => _animator.SetBool(DeathHash, true))
                .AddTo(this);
        }

        private void OnValidate()
        {
            if (_animator == null) _animator = GetComponent<Animator>();
            if (_player == null) _player = GetComponent<PlayerInstance>();
        }

        private void Update()
        {
            var inputX = Mathf.Abs(_player.PlayerController.MoveInput.x);
            var speed = inputX > 0.01f 
                ? Mathf.Abs(_player.PlayerController.VelocityX) 
                : 0f;

            _animator.SetFloat(SpeedHash, speed);
        }
    }
}