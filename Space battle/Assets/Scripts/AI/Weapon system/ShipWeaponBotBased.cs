using System;
using SpaceBattle.Spaceship;
using UnityEngine;

namespace SpaceBattle.AI
{
    public class ShipWeaponBotBased : ShipWeapon
    {
        #region Fields

        [Space]
        [SerializeField] private ShootBehaviour _shootBehaviour;

        #endregion

        protected override void Initialize()
        {
            base.Initialize();

            SetUpShootBehaviourPresence();
        }

        private void SetUpShootBehaviourPresence()
        {
            if (!_shootBehaviour)
                throw new NullReferenceException("Shooting behaviour isn't assigned");

            _shootBehaviour = Instantiate(_shootBehaviour);
        }

        #region Shooting

        private void Update() => ShootIfSeeTarget();

        private void ShootIfSeeTarget()
        {
            Transform target = FindAimTarget();

            if (target)
                _shootBehaviour.Shoot(transform, target, () => ShootFromMain(target), () => ShootFromSecondary(target));
        }

        #endregion

    }
}
