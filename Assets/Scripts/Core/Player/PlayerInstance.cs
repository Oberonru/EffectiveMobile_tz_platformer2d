using Core.Configs.Player;
using UnityEngine;
using Zenject;

namespace Core.Player
{
    public class PlayerInstance : MonoBehaviour
    {
        [Inject] private PlayerTestConfig _config;

        private void Awake()
        {
            print(_config.PlayerName);
        }
    }
}