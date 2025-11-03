using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Services;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.Player.Components
{
    [RequireComponent(typeof(PlayerInstance))]
    public class PlayerDataHandler : MonoBehaviour
    {
        [Inject] private StorageService _storage;
        [SerializeField] private PlayerInstance _player;

        public IReadOnlyReactiveProperty<int> OnMoneyChanged => _onMoney;
        private ReactiveProperty<int> _onMoney = new();

        private async UniTask Awake()
        {
            try
            {
               InitHealth();
                var data = await _storage.Load();

                await UniTask.WaitUntil(() => _storage.PlayerData != null);

                _onMoney.Value = data.PlayerMoney;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _onMoney.Value = 0;
            }

        }

        private void OnValidate()
        {
            if (_player == null) _player = GetComponent<PlayerInstance>();
        }

        public void AddMoney(int money)
        {
            _storage.PlayerData.PlayerMoney += money;

            _onMoney.Value = _storage.PlayerData.PlayerMoney;
        }

        private void InitHealth()
        {
            var stats = _player.Stats;
            var health = _player.Health;
        
            health.InitMaxHealth(stats.MaxHealth + stats.PlayerLevel);
            health.CurrentHealth = stats.MaxHealth;
        }
    }
}