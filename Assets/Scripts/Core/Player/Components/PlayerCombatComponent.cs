using Core.BaseComponents;
using Core.CombatSystem;
using UniRx;
using UnityEngine;

namespace Core.Player.Components
{
    public class PlayerCombatComponent : MonoBehaviour
    {
        [SerializeField] private PlayerInstance _player;
        [SerializeField] private HitBoxDetector _detector;

        private HealthComponent _target;

        private void OnEnable()
        {
            _detector.OnEnter.
                Subscribe(hitBox => _target = hitBox.Health).
                AddTo(this);
            
            _detector.OnStay.
                Subscribe(hitBox => _target = hitBox.Health).
                AddTo(this);
            
            _detector.OnExit.
                Subscribe(hitBox => _target = null).
                AddTo(this);
            
            _player.PlayerController.OnAttack.
                Where(_ => _target != null).
                Subscribe(_ => AttackHandle()).
                AddTo(this);
        }

        private void AttackHandle()
        {
            //TODO: add player damage field
            
            print(_target);
            print(_target.CurrentHealth);
            _target.TakeDamage(1);
        }
    }
}