using System;
using Core.CombatSystem;
using UniRx;
using UnityEngine;

namespace Core.BaseComponents
{
    public class HealthComponent : MonoBehaviour
    {
        public IObservable<DamageContext> OnHit => _onHit;
        private readonly Subject<DamageContext> _onHit = new();

        public IObservable<int> OnHealthChanged => _onHealthChanged;
        private readonly Subject<int> _onHealthChanged = new();

        public IObservable<Unit> OnDead => _onDead;
        private readonly Subject<Unit> _onDead = new();

        private int _maxHealth;
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

        public void TakeDamage(DamageContext ctx)
        {
            if (_currentHealth <= 0 || ctx.Damage <= 0) return;

            _currentHealth = Mathf.Clamp(_currentHealth - ctx.Damage, 0, _maxHealth);

            _onHit?.OnNext(ctx);
            _onHealthChanged?.OnNext(_currentHealth);
            if (_currentHealth <= 0) _onDead?.OnNext(Unit.Default);
        }

        public void Heal(int amount)
        {
            if (amount <= 0) return;

            print("heal amount: " + amount);

            _currentHealth = Mathf.Clamp(amount + _currentHealth, 0, _maxHealth);
            _onHealthChanged.OnNext(_currentHealth);
        }
    }
}