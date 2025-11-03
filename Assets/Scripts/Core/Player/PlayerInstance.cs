using Core.BaseComponents;
using Core.Configs.Player;
using Core.Handlers;
using Core.Interfaces;
using Core.Player.Components;
using UnityEngine;
using Zenject;

namespace Core.Player
{
    [RequireComponent(typeof(CorpseHandler))]
    [RequireComponent(typeof(StateComponentHandler))]
    [RequireComponent(typeof(ItemDetector))]
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(PlayerAnimatorController))]
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent(typeof(ItemDetector))]
    [RequireComponent(typeof(PlayerDataHandler))]
    public class PlayerInstance : MonoBehaviour, IStateComponent
    {
        [Inject] private PlayerConfig _config;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private PlayerAnimatorController _animatorController;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private ItemDetector _itemDetector;
        [SerializeField] private PlayerDataHandler _playerDataHandler;
        
        public PlayerConfig Stats => _config;
        public PlayerController PlayerController => _playerController;
        public PlayerAnimatorController AnimatorController => _animatorController;
        public HealthComponent Health => _healthComponent;
        public ItemDetector ItemDetector => _itemDetector;
        public PlayerDataHandler DataHandler => _playerDataHandler;

        private void Awake()
        {
            _healthComponent.InitMaxHealth(_config.MaxHealth + _config.PlayerLevel);
            _healthComponent.CurrentHealth = _healthComponent.MaxHealth;
        }

        private void OnValidate()
        {
            if (_playerController == null) _playerController = GetComponent<PlayerController>();
            if (_animatorController == null) _animatorController = GetComponent<PlayerAnimatorController>();
            if (_itemDetector == null) _itemDetector = GetComponent<ItemDetector>();
        }

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = false;
        }
    }
}