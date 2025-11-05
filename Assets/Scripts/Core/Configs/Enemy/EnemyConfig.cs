using Infrastructure.Configs;
using UnityEngine;

namespace Core.Configs.Enemy
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/Enemy/EnemyConfig")]

    public class EnemyConfig : ScriptableConfig
    {
        [SerializeField] private int _baseMaxHealth;
        [SerializeField] private int _baseDamage;
        [SerializeField] private float _throwingForce;
        
        public int BaseMaxHealth => _baseMaxHealth;
        public int BaseDamage => _baseDamage;
        public float ThrowingForce => _throwingForce;
    }
}