using System;
using UnityEngine;

namespace SpaceBattle
{
    public class ShipHealth : MonoBehaviour, IDamageable
    {
        [SerializeField, Min(0)] private int _health;

        private int _currentHealth;

        public event Action<int, int> OnHealthChanged;
        public event Action OnDeath;

        private IDeathSubscriber _deathSubscriber = new DeathSubscriber();

        private void Start()
        {
            IncreaseHealthToMax();

            _deathSubscriber.SubscribeAttachedComponents(this);
        }

        private void IncreaseHealthToMax() => _currentHealth = _health;

        public void Damage(int damage)
        {
            if (_currentHealth <= 0) return;

            _currentHealth -= damage;

            OnHealthChanged?.Invoke(_currentHealth, _health);

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;

                Die();
                OnDeath?.Invoke();
            }
        }

        private void Die() => gameObject.SetActive(false);

    }
}
