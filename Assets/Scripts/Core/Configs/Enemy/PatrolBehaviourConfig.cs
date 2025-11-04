using Infrastructure.Configs;
using UnityEngine;

namespace Core.Enemies.Configs
{
    [CreateAssetMenu(fileName = "PatrolBehaviourConfig", menuName = "Configs/Enemy/PatrolBehaviourConfig")]
    public class PatrolBehaviourConfig : ScriptableConfig
    {
        [Header("Движение")]
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _movementDistance = 3f;

        [Header("Обнаружение")]
        [SerializeField] private float _forwardRayDistance = 0.5f;
        [SerializeField] private float _downRayDistance = 1f;

        [Header("Стабилизация")]
        [SerializeField] private float _turnCooldown = 0.2f;
        
        public float Speed => _speed;
        public float MovementDistance => _movementDistance;
        public float ForwardRayDistance => _forwardRayDistance;
        public float DownRayDistance => _downRayDistance;
        public float TurnCooldown => _turnCooldown;
    }
}