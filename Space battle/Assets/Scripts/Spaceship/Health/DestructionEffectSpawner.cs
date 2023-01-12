using System;
using SpaceBattle.Visual;
using UnityEngine;

namespace SpaceBattle
{

    [RequireComponent(typeof(ShipHealth))]
    public class DestructionEffectSpawner : MonoBehaviour
    {
        [SerializeField] private ParticleEffect _destructionEffect;
        private ShipHealth _shipHealth;

        #region Initialization

        private void Initialize()
        {
            if (_shipHealth && _destructionEffect) return;

            _shipHealth = gameObject.GetComponentWithException<ShipHealth>();

            if (!_destructionEffect) throw new NullReferenceException("Destruction effect isn't assigned");
        }

        private void OnEnable()
        {
            Initialize();

            _shipHealth.OnDeath += SpawnEffect;
        }

        private void OnDisable()
        {
            _shipHealth.OnDeath -= SpawnEffect;
        }

        #endregion

        private void SpawnEffect()
        {
            ParticleEffect destructionEffect = Instantiate(_destructionEffect, transform.position, Quaternion.identity);
            destructionEffect.StopAfterDelay();
        }
    }
}
