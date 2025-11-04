using Core.BaseComponents;
using Core.Configs.Enemy;
using Core.Enemies.Components;
using Core.Handlers;
using UnityEngine;
using Zenject;

namespace Core.Enemies
{
    [RequireComponent(typeof(CorpseHandler))]
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent(typeof(EnemyDataHandler))]
    public class EnemyInstance : MonoBehaviour, IEnemyInstance
    {
        [Inject] private EnemyConfig _enemyConfig;
        [SerializeField] private HealthComponent _health;
        [SerializeField] private EnemyDataHandler _dataHandler;
        public EnemyConfig Stats => _enemyConfig;
        public HealthComponent Health => _health;
        public EnemyDataHandler DataHandler => _dataHandler;

        private void OnValidate()
        {
            if (_health == null) _health = GetComponent<HealthComponent>();
            if (_dataHandler == null) _dataHandler = GetComponent<EnemyDataHandler>();
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