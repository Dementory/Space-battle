using System;
using SpaceBattle.Battle;
using UnityEngine;

namespace SpaceBattle.Spaceship
{

    public abstract class ShipWeapon : MonoBehaviour, IResponsiveToDeath, ITeamDependent
    {
        [SerializeField] private Weapon[] _mainWeapons;
        [SerializeField] private Weapon[] _secondaryWeapon;
        [Space]
        [SerializeField] private TargetFinder _targetFinder;

        private bool _isDead;

        private TeamData _team;

        #region Initialization

        private void Start() => Initialize();

        protected virtual void Initialize()
        {
            if (_targetFinder == null) throw new NullReferenceException("Target finder is not assigned");
        }

        #endregion

        protected void ShootFromMain(Transform aimTarget = null) => ShootFromWeapons(_mainWeapons, aimTarget);

        protected void ShootFromSecondary(Transform aimTarget = null) => ShootFromWeapons(_secondaryWeapon, aimTarget);

        private void ShootFromWeapons(Weapon[] weapons, Transform aimTarget = null)
        {
            if (_isDead) return;

            if (!aimTarget)
                aimTarget = FindAimTarget();

            foreach (Weapon weapon in weapons)
                weapon.Fire(aimTarget);
        }

        protected Transform FindAimTarget()
        {
            Ship foundShip = _targetFinder.FindTarget(transform, _team);
            Transform aimTarget = foundShip ? foundShip.transform : null;

            return aimTarget;
        }

        public void OnDeath() => _isDead = true;

        public void AssignTeam(TeamData team) => _team = team;

        public enum Order
        {
            Main,
            Secondary
        }

    }

}
