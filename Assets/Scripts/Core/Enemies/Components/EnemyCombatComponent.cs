using Core.CombatSystem;
using Core.Configs.Enemy;
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
        [Inject] private EnemyConfig _enemyConfig;
        [SerializeField] private HitBoxDetector _detector;
        [SerializeField] private EnemyInstance _enemy;

        private float _time = -Mathf.Infinity;

        private void OnValidate()
        {
            if (_detector == null) _detector = GetComponentInChildren<HitBoxDetector>();
            if (_enemy == null) _enemy = GetComponent<EnemyInstance>();
        }

        private void OnEnable()
        {
            _detector.OnEnter.Subscribe(hitbox =>
            {
                if (hitbox is PlayerHitBox playerHitBox)
                {
                    AttackPlayer(playerHitBox);
                }
            }).AddTo(this);
        }

        private void AttackPlayer(PlayerHitBox playerHitBox)
        {
            if (Time.time >= _time + _config.Invulnerability)
            {
                _time = Time.time;
                
                playerHitBox.Health.TakeDamage
                (new DamageContext
                (_enemy.DataHandler.EnemyData.Damage,
                    new Vector2(_enemy.Transform.position.x, _enemy.Transform.position.y), _enemyConfig.ThrowingForce));
                
                _audioHandler.PlaySfx(playerHitBox.Clips);
            }
        }
    }
}