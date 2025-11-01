using Core.Configs.Player;
using Core.Player.Components;
using UnityEngine;
using Zenject;

namespace Core.Player
{
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(PlayerAnimatorController))]
    public class PlayerInstance : MonoBehaviour
    {
        [Inject] private PlayerConfig _playerConfig;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private PlayerAnimatorController _animatorController;
        
        public PlayerConfig Stats => _playerConfig;
        public PlayerController PlayerController => _playerController;
        public PlayerAnimatorController AnimatorController => _animatorController;

        private void OnValidate()
        {
            if (_playerController == null) _playerController = GetComponent<PlayerController>();
            if (_animatorController == null) _animatorController = GetComponent<PlayerAnimatorController>();
        }
    }
}