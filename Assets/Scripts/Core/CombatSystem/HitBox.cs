using Core.BaseComponents;
using UnityEngine;

namespace Core.CombatSystem
{
    [RequireComponent(typeof(Collider2D))]
    public class HitBox : MonoBehaviour, IHitBox
    {
        public HealthComponent Health => _health;
     
        [SerializeField] private HealthComponent _health;
        [SerializeField] private Collider2D _collider;
        public AudioClip[] Clips => _tarcks;
        [SerializeField] private AudioClip[] _tarcks;
        
        private void OnValidate()
        {
            if (_collider == null) _collider = GetComponent<Collider2D>();
        }
    }
}