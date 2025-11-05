using Infrastructure.Configs;
using UnityEngine;

namespace Core.Configs.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player/PlayerConfig")]
    public class PlayerConfig :  ScriptableConfig
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _jumpForce = 3f;
        [SerializeField] private float _groundCheckDistance = 0.1f;
        [SerializeField] private float _groundNormalThreshold = 0.65f;
        [SerializeField] private int _maxHealth = 5; 
        [SerializeField] private int playerLevel = 1; 
        [SerializeField] private float _invulnerability = 1f;
        [SerializeField] private int _baseDamage;


        public float Speed => _speed;
        public float JumpForce => _jumpForce;
        public float GroundCheckDistance => _groundCheckDistance;
        public float GroundNormalThreshold => _groundNormalThreshold;
        public int MaxHealth => _maxHealth;
        public int PlayerLevel => playerLevel;
        public float Invulnerability => _invulnerability;
        public int BaseDamage => _baseDamage;
    }
}