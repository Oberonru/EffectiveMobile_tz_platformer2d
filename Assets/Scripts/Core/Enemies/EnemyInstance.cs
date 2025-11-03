using Core.BaseComponents;
using UnityEngine;

namespace Core.Enemies
{
    [RequireComponent(typeof(HealthComponent))]
    public class EnemyInstance : MonoBehaviour
    {
        [SerializeField] private HealthComponent _health;
        
        public HealthComponent Health => _health;
    }
}