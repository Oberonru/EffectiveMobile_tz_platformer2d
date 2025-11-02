using System;
using UniRx;
using UnityEngine;

namespace Core.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 5;

        public IObservable<Unit> OnHit => _onHit;
        private readonly Subject<Unit> _onHit = new();

        public IObservable<int> OnHealthChanged => _onHealthChanged;
        private readonly Subject<int> _onHealthChanged = new();

        public IObservable<Unit> OnDead => _onDead;
        private readonly Subject<Unit> _onDead = new();

        private int _currentHealth;

        public void InitMaxHealth(int maxHealth)
        {
            _maxHealth = maxHealth;
        }

        public int MaxHealth => _maxHealth;
        
        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        public void TakeDamage(int amount)
        {
            if (_currentHealth <= 0 || amount <= 0) return;

            _currentHealth = Mathf.Clamp(_currentHealth - amount, 0, _maxHealth);

            _onHit?.OnNext(Unit.Default);
            _onHealthChanged?.OnNext(_currentHealth);
            if (_currentHealth <= 0) _onDead?.OnNext(Unit.Default);
        }

        public void Heal(int amount)
        {
            if (amount <= 0) return;

            _currentHealth = Mathf.Clamp(amount + _currentHealth, 0, _maxHealth);
            _onHealthChanged.OnNext(_currentHealth);
        }
    }
}