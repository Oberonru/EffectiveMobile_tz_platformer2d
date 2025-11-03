using Core.BaseComponents;
using Core.Handlers;
using UnityEngine;

namespace Core.Enemies
{
    [RequireComponent(typeof(CorpseHandler))]
    [RequireComponent(typeof(HealthComponent))]
    public class EnemyInstance : MonoBehaviour, IEnemyInstance
    {
        [SerializeField] private HealthComponent _health;
        
        public HealthComponent Health => _health;
        
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