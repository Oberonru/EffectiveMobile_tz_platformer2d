using Infrastructure.Configs;
using UnityEngine;

namespace Core.Configs.Player
{
    [CreateAssetMenu(fileName = "PlayerTestConfig", menuName = "Configs/PlayerTestConfig")]
    public class PlayerTestConfig :  ScriptableConfig
    {
        [SerializeField] private string _playerName = "Test Player";

        public string PlayerName => _playerName;
    }
}