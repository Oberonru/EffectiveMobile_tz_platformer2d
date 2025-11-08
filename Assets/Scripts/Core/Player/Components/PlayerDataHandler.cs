using System;
using System.Collections.Generic;
using System.Linq;
using Core.Items;
using Core.Items.ItemObjects;
using Core.Player.Model;
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
        [Inject] private ItemsRepository _repository;
        [SerializeField] private PlayerInstance _player;

        public IReadOnlyReactiveProperty<int> MoneyChanged => _money;
        private ReactiveProperty<int> _money = new();

        public ISubject<(Item, int)> OnInventoryChanged => _onInventoryChanged;
        private Subject<(Item, int)> _onInventoryChanged = new();
        
        private GameData _gameData;
        private Inventory _inventory;

        private async UniTask Awake()
        {
            try
            {
                InitHealth();
                _gameData = await _storage.Load();

                _inventory = new Inventory();
                _inventory.InventoryItems = LoadInventory(_gameData);

                await UniTask.WaitUntil(() => _storage.GameData != null);

                _money.Value = _gameData.PlayerData.PlayerMoney;
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

        public void AddItem(Item item, int count)
        {
            var itemAnalog = _gameData.PlayerData.Items.FirstOrDefault(el => el.Id == item.ScriptableItem.GUID);

            if (itemAnalog != null)
            {
                itemAnalog.Amount += count;
            }
            else
            {
                _gameData.PlayerData.Items.Add(new ItemData
                {
                    Id = item.ScriptableItem.GUID, Amount = count
                });
            }

            for (int i = 0; i < count; i++)
            {
                _inventory.AddItem(item);
            }

            _onInventoryChanged.OnNext((item, count));
        }

        private List<Item> LoadInventory(GameData gameData)
        {
            if (gameData == null) return null;

            var itemsData = gameData.PlayerData.Items;
            var runtimeItems = new List<Item>();

            foreach (var itemData in itemsData)
            {
                var scriptable = _repository.GetItemById(itemData.Id);
                if (scriptable == null) continue;

                for (int i = 0; i < itemData.Amount; i++)
                {
                    var obj = scriptable.CreateItem();
                    _inventory.AddItem(obj);
                    runtimeItems.Add(obj);
                }
            }
            
            return runtimeItems;
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
