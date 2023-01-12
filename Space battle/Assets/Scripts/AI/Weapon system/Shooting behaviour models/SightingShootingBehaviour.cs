using System;
using SpaceBattle.Editor;
using SpaceBattle.Spaceship;
using UnityEngine;

namespace SpaceBattle.AI
{
    [CreateAssetMenu(fileName = nameof(SightingShootingBehaviour), menuName = AIScriptableObjects.SHOOTING_BEHAVIOUR_MENU_FOLDER + nameof(SightingShootingBehaviour))]
    public class SightingShootingBehaviour : ShootBehaviour
    {

        #region Fields

        [Tooltip("Required course match to shoot from main guns")]
        [SerializeField, Range(-1, 1)] private float _mainGunRequiredMatchLevel;

        [Tooltip("Required course match to shoot from secondary guns")]
        [SerializeField, Range(-1, 1)] private float _secondaryGunRequiredMatchLevel;

        private Vector3 _previousTargetMoveDirection;
        private Vector3 _previousTargetPosition;

        #endregion

        #region Shooting

        public override void Shoot(Transform shootingEntity, Transform target, Action ShootFromMain, Action ShootFromSecondary)
        {
            Vector3 targetPosition = target.position;
            Vector3 moveDirection = (targetPosition - _previousTargetPosition).normalized;
            float courseMatch = moveDirection == Vector3.zero ? 1 : Vector3.Dot(moveDirection, _previousTargetMoveDirection);

            TryShoot(courseMatch, ShootFromMain, ShootFromSecondary);

            _previousTargetMoveDirection = moveDirection;
            _previousTargetPosition = targetPosition;
        }

        private void TryShoot(float courseMatch, Action ShootFromMain, Action ShootFromSecondary)
        {
            if (!CanShoot(courseMatch)) return;

            ShipWeapon.Order weaponOrder = GetWeaponOrder(courseMatch);

            if (weaponOrder == ShipWeapon.Order.Main)
                ShootFromMain();
            else if (weaponOrder == ShipWeapon.Order.Secondary)
                ShootFromSecondary();
        }

        private bool CanShoot(float courseMatch) =>
            courseMatch >= _mainGunRequiredMatchLevel || courseMatch >= _secondaryGunRequiredMatchLevel;

        private ShipWeapon.Order GetWeaponOrder(float courseMatch)
        {
            if (_mainGunRequiredMatchLevel >= _secondaryGunRequiredMatchLevel)
            {
                if (courseMatch >= _secondaryGunRequiredMatchLevel && courseMatch < _mainGunRequiredMatchLevel)
                    return ShipWeapon.Order.Secondary;
                else
                    return ShipWeapon.Order.Main;
            }
            else
            {
                if (courseMatch >= _mainGunRequiredMatchLevel && courseMatch < _secondaryGunRequiredMatchLevel)
                    return ShipWeapon.Order.Main;
                else
                    return ShipWeapon.Order.Secondary;
            }
        }

        #endregion

    }
}
