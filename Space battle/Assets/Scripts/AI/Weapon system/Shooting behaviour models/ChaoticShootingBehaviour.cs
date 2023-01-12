using System;
using SpaceBattle.Editor;
using SpaceBattle.Spaceship;
using UnityEngine;

namespace SpaceBattle.AI
{

    [CreateAssetMenu(fileName = nameof(ChaoticShootingBehaviour), menuName = AIScriptableObjects.SHOOTING_BEHAVIOUR_MENU_FOLDER + nameof(ChaoticShootingBehaviour))]
    public class ChaoticShootingBehaviour : ShootBehaviour
    {
        public override void Shoot(Transform shootingEntity, Transform target, Action ShootFromMain, Action ShootFromSecondary)
        {
            ShipWeapon.Order randomWeapon = (ShipWeapon.Order)UnityEngine.Random.Range(0, 2);

            if (randomWeapon == ShipWeapon.Order.Main)
                ShootFromMain();
            else if (randomWeapon == ShipWeapon.Order.Secondary)
                ShootFromSecondary();
        }
    }
}
