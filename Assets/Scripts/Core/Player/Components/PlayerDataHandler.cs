using System;
using Core.Items.SO;
using Cysharp.Threading.Tasks;
using Infrastructure.Services;
using Storage.Model;
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

        public IReadOnlyReactiveProperty<int> MoneyChanged => _money;
        private ReactiveProperty<int> _money = new();

        private async UniTask Awake()
        {
            try
            {
                InitHealth();
                var data = await _storage.Load();

                await UniTask.WaitUntil(() => _storage.GameData != null);

                _money.Value = data.PlayerData.PlayerMoney;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _money.Value = 0;
            }
        }

        private void OnValidate()
        {
            if (_player == null) _player = GetComponent<PlayerInstance>();
        }

        public void AddMoney(int money)
        {
            _storage.GameData.PlayerData.PlayerMoney += money;

            _money.Value = _storage.GameData.PlayerData.PlayerMoney;
        }

        public void AddItem(ScriptableItem item)
        {
            var itemData = new ItemData(item.Amount);
            
            _storage.GameData.PlayerData.Items.Add(itemData);
        }

        private void InitHealth()
        {
            var stats = _player.Stats;
            var health = _player.Health;

            var maxHealth = stats.MaxHealth + stats.PlayerLevel;
            
            health.InitMaxHealth(maxHealth);
            health.CurrentHealth = maxHealth;
        }
    }
}