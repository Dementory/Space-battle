using UnityEngine;
using SpaceBattle.Visual;
using System;
using System.Threading.Tasks;

namespace SpaceBattle.Spaceship
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _damage;
        [SerializeField, Min(0)] private float _moveSpeed;

        [SerializeField, Min(0)] private float _flightDistance;

        private ParticleEffectPool _impactEffectPool;

        protected Rigidbody Rigidbody;
        private Action DestroyBullet;

        protected float MoveSpeed => _moveSpeed;

        #region Initialization

        public virtual void Initialize()
        {
            InitializeDestroying();
            InitializeRigidbody();
        }

        private void InitializeRigidbody()
        {
            if (Rigidbody) return;

            Rigidbody = GetComponent<Rigidbody>();

            Rigidbody.useGravity = false;
        }

        private void InitializeDestroying()
        {
            if (DestroyBullet == null)
                DestroyBullet = () => MonoBehaviour.Destroy(gameObject);
        }

        public void AssignImpactEffect(ParticleEffectPool impactEffectPool) => _impactEffectPool = impactEffectPool;

        #endregion

        public virtual void Shoot(Vector3 direction)
        {
            if (!Rigidbody) throw new NullReferenceException("Rigidbody hasn't been initialized");

            Rigidbody.velocity += direction * _moveSpeed;
        }

        #region Destroy

        public async void ExplodeAfterDelay()
        {
            float delayInSeconds = _flightDistance / _moveSpeed;

            int delayInMiliseconds = (int)(delayInSeconds * 1000);
            await Task.Delay(delayInMiliseconds);

            Explode();
        }

        public void OverrideDestroy(Action DestroyOverride) => DestroyBullet = DestroyOverride;

        #endregion

        #region Colision

        private void OnCollisionEnter(Collision collision) => OnCollision(collision);

        protected virtual void OnCollision(Collision collision)
        {
            DamageCollidedObject(collision);
            Explode();
        }

        private void Explode()
        {
            SpawnExplosionEffect();
            DestroyBullet?.Invoke();
        }

        private void SpawnExplosionEffect()
        {
            if (!_impactEffectPool) return;

            Transform impactEffect = _impactEffectPool.Get().transform;
            impactEffect.position = transform.position;
            impactEffect.rotation = transform.rotation;
        }

        private void DamageCollidedObject(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
                damageable.Damage(_damage);
        }

        #endregion

    }
}
