using Core.CombatSystem;
using Core.Configs.Player;
using Core.Handlers;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.Enemies.Components
{
    [RequireComponent(typeof(HitBoxDetector))]
    public class EnemyCombatComponent : MonoBehaviour
    {
        [Inject] private PlayerConfig _config;
        [Inject] private IAudioHandler _audioHandler;
        [SerializeField] private HitBoxDetector _detector;
        [SerializeField] private EnemyInstance _enemy;

        private float _time = -Mathf.Infinity;

        private void OnValidate()
        {
            if (_detector == null) _detector = GetComponent<HitBoxDetector>();
            if (_enemy == null) _enemy = GetComponent<EnemyInstance>();
        }

        private void OnEnable()
        {
            _detector.OnEnter.
                Subscribe(hitbox =>
            {
                if (hitbox is PlayerHitBox playerHitBox)
                {
                    HandleHit(playerHitBox);
                }
            }).AddTo(this);
        }

        private void HandleHit(PlayerHitBox playerHitBox)
        {
            if (Time.time >= _time + _config.Invulnerability)
            {
                _time = Time.time;
                playerHitBox.Health.TakeDamage(_enemy.DataHandler.EnemyData.Damage);
                _audioHandler.PlaySfx(playerHitBox.Clips);
            }
        }
    }
}