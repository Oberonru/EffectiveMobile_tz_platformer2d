using Core.Configs.Player;
using Core.Player.Components;
using UnityEngine;
using Zenject;

namespace Core.Player
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerInstance : MonoBehaviour
    {
        [Inject] private PlayerConfig _playerConfig;
        [SerializeField] private PlayerController _playerController;
        
        public PlayerConfig Stats => _playerConfig;
        public PlayerController PlayerController => _playerController;

        private void OnValidate()
        {
            if (_playerController == null) _playerController = GetComponent<PlayerController>();
        }
    }
}