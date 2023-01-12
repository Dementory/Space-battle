using SpaceBattle.Visual;
using UnityEngine;

namespace SpaceBattle.Spaceship
{

    [RequireComponent(typeof(BulletPool))]
    public class Firearm : Weapon
    {
        [Tooltip("Shoot rate in seconds")]
        [SerializeField] private float _shootRate;

        private BulletPool _bulletPool;
        private ParticleEffectPool _impactEffectPool;

        private float _timeElapsedSinceLastShot;

        #region Initialization

        private void Start() => Initialize();

        private void Initialize()
        {
            AssignBulletPool();
            AssignImpactEffectPool();
        }

        private void AssignBulletPool()
        {
            _bulletPool = gameObject.GetComponentWithException<BulletPool>();
        }

        private void AssignImpactEffectPool()
        {
            if (TryGetComponent(out ParticleEffectPool impactEffectPool))
                _impactEffectPool = impactEffectPool;
        }

        #endregion

        private void Update() => RestoreTimeSinceLastShot();

        private void RestoreTimeSinceLastShot()
        {
            if (_timeElapsedSinceLastShot >= _shootRate) return;

            _timeElapsedSinceLastShot += Time.deltaTime;
        }

        public override void Fire(Transform aimTarget)
        {
            if (_timeElapsedSinceLastShot < _shootRate) return;

            _timeElapsedSinceLastShot = 0;

            foreach (Transform spawnPoint in BulletSpawnPoints)
            {
                Bullet bullet = _bulletPool.Get();
                bullet.transform.position = spawnPoint.position;
                bullet.transform.rotation = spawnPoint.rotation;

                bullet.AssignImpactEffect(_impactEffectPool);

                if (bullet.TryGetComponent(out ITargetRequester targetRequester))
                    targetRequester.AssignTarget(aimTarget);

                bullet.Shoot(spawnPoint.forward);
            }
        }
    }
}
