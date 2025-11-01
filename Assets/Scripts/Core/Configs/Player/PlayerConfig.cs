using Infrastructure.Configs;
using UnityEngine;

namespace Core.Configs.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player/PlayerConfig")]
    public class PlayerConfig :  ScriptableConfig
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _jumpForce = 3f;

        public float Speed => _speed;
        public float JumpForce => _jumpForce;
    }
}