using Core.BaseComponents;
using Core.CombatSystem;
using Core.Handlers;
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

            _player.PlayerController.OnAttack.Where(_ => _target != null).Subscribe(_ => AttackHandle()).AddTo(this);
        }

        private void AttackHandle()
        {
            _target.TakeDamage(1);

            if (_currentHitBox != null)
            {
                _audioHandler.PlaySfx(_currentHitBox.Clips);
            }
        }
    }
}