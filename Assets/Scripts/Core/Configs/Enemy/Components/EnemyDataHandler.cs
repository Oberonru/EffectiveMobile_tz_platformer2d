using System;
using System.Linq;
using Core.Enemies;
using Cysharp.Threading.Tasks;
using Infrastructure.Services;
using Storage.Model;
using UnityEngine;
using Zenject;

namespace Core.Configs.Enemy.Components
{
    public class EnemyDataHandler : MonoBehaviour
    {
        [Inject] private StorageService _storage;
        [Inject] private EnemyConfig _config;
        [SerializeField] private EnemyInstance _enemy;

        private GameData _gameData;
        private EnemyData _enemyData;

        private async void Awake()
        {
            try
            {
                _gameData = await _storage.Load();
                await UniTask.WaitUntil(() => _gameData != null);

                _enemyData = _gameData.Enemies.FirstOrDefault(e => e.CurrentHealth > 0);

                if (_enemyData == null)
                {
                    _enemyData = new EnemyData(
                        1,
                        _config.BaseDamage,
                        _config.BaseMaxHealth,
                        _config.BaseMaxHealth
                    );

                    _gameData.Enemies.Add(_enemyData);
                }

                InitHealthFromData();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        private void InitHealthFromData()
        {
            var health = _enemy.Health;

            health.InitMaxHealth(_enemyData.MaxHealth);
            health.CurrentHealth = _enemyData.CurrentHealth;
            print("_enemyData.CurrentHealth " + _enemyData.CurrentHealth);
            print("enemy current " + _enemy.Health.CurrentHealth);
            print("enemy max " + _enemy.Health.MaxHealth);
        }
    }
}