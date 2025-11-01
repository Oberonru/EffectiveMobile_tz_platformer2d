using Core.Components;
using Core.Configs.Player;
using Core.Player.Components;
using UnityEngine;
using Zenject;

namespace Core.Player
{
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(PlayerAnimatorController))]
    [RequireComponent(typeof(HealthComponent))]
    public class PlayerInstance : MonoBehaviour
    {
        [Inject] private PlayerConfig _config;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private PlayerAnimatorController _animatorController;
        [SerializeField] private HealthComponent _healthComponent;
        
        public PlayerConfig Stats => _config;
        public PlayerController PlayerController => _playerController;
        public PlayerAnimatorController AnimatorController => _animatorController;
        public HealthComponent PlayerHealth => _healthComponent;

        private void Start()
        {
            _healthComponent.InitMaxHealth(_config.MaxHealth * _config.PlayerMultiply);
        }

        private void OnValidate()
        {
            if (_playerController == null) _playerController = GetComponent<PlayerController>();
            if (_animatorController == null) _animatorController = GetComponent<PlayerAnimatorController>();
        }
    }
}