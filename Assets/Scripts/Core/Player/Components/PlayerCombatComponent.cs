using System;
using Core.BaseComponents;
using Core.CombatSystem;
using Core.Handlers;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.Player.Components
{
    public class PlayerCombatComponent : MonoBehaviour
    {
        [Inject] private IAudioHandler _audioHandler;
        [SerializeField] private PlayerInstance _player;
        [SerializeField] private HitBoxDetector _detector;

        private HealthComponent _target;
        private IHitBox _currentHitBox;
        private SpriteRenderer _spriteRenderer;

        private void OnEnable()
        {
            _detector.OnEnter.Subscribe(hitBox =>
            {
                _currentHitBox = hitBox;
                _target = hitBox.Health;
            }).AddTo(this);

            _detector.OnStay.Subscribe(hitBox =>
            {
                _currentHitBox = hitBox;
                _target = hitBox.Health;
            }).AddTo(this);

            _detector.OnExit.Subscribe(hitBox =>
            {
                _currentHitBox = null;
                _target = null;
            }).AddTo(this);

            _player.PlayerController.AttackStream.
                Where(_ => _target != null).
                Subscribe(_ => AttackHandle())
                .AddTo(this);

            _player.Health.OnHit.
                Subscribe(ctx =>
                {
                    HandleIncomingHit(ctx);
                }).AddTo(this);
        }

        private void Start()
        {
            if (_spriteRenderer == null) _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void HandleIncomingHit(DamageContext ctx)
        {
            ThrowingPlayer(ctx);
        }

        private void ThrowingPlayer(DamageContext ctx)
        {
            var direction = (_player.transform.position - (Vector3)ctx.AttackerPosition).normalized;
            direction = new Vector3(direction.x, 0, direction.z);
            
            _player.PlayerController.Disable();
            
            _player.PlayerController.Rigidbody.velocity = Vector2.zero; 
            _player.PlayerController.Rigidbody.AddForce(direction * ctx.ThrowingForce, ForceMode2D.Impulse);
            
            EnableController().Forget();
        }

        private async UniTask EnableController()
        {
            if (!_player.Health.IsAlive()) return;
            
            await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: this.GetCancellationTokenOnDestroy());
            _player.PlayerController.Enable();
        }
        
        private void AttackHandle()
        {
            if (_currentHitBox == null || _target == null) return;

            var ctx = new DamageContext(_player.Stats.BaseDamage,
                new Vector2(_player.Transform.position.x, _player.Transform.position.y), _player.Stats.ThrowingForce);

            _target.TakeDamage(ctx);
            _audioHandler.PlaySfx(_currentHitBox.Clips);
        }
    }
}