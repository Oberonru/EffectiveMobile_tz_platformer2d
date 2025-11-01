using Infrastructure.Configs;
using UnityEngine;

namespace Core.Configs.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player/PlayerConfig")]
    public class PlayerConfig :  ScriptableConfig
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _jumpForce = 3f;
        [SerializeField] private float groundCheckDistance = 0.1f;
        [SerializeField] private float groundNormalThreshold = 0.65f;

        public float Speed => _speed;
        public float JumpForce => _jumpForce;
        public float GroundCheckDistance => groundCheckDistance;
        public float GroundNormalThreshold => groundNormalThreshold;
    }
}