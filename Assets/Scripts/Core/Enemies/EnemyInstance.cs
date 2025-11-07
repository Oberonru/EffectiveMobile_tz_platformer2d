using Core.BaseComponents;
using Core.Configs.Enemy;
using Core.Enemies.Components;
using Core.Handlers;
using UnityEngine;
using Zenject;

namespace Core.Enemies
{
    [RequireComponent(typeof(CorpseHandler))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent(typeof(EnemyDataHandler))]
    public class EnemyInstance : MonoBehaviour, IEnemyInstance
    {
        [Inject] private EnemyConfig _enemyConfig;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private HealthComponent _health;
        [SerializeField] private EnemyDataHandler _dataHandler;
        public Transform Transform => transform;
        
        public EnemyConfig Stats => _enemyConfig;
        public Rigidbody2D Rigidbody => _rigidbody;
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