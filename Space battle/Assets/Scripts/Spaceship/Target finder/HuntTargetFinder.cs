using System.Collections.Generic;
using SpaceBattle.Battle;
using SpaceBattle.Editor;
using SpaceBattle.Spaceship;
using UnityEngine;

namespace SpaceBattle.AI
{

    [CreateAssetMenu(fileName = nameof(HuntTargetFinder), menuName = WeaponScriptableObjects.TARGET_FINDER_MENU_FOLDER + nameof(HuntTargetFinder))]

    public class HuntTargetFinder : TargetFinder
    {

        #region Searching

        public override Ship FindTarget(Transform finder, TeamData team = null)
        {
            List<Ship> shipsInSearchArea = GetAllShipsInSearchArea(finder, team);
            Ship closestShip = GetClosestShip(finder, shipsInSearchArea);

            return closestShip;
        }

        #endregion

        #region Gizmos

        public override void DrawGizmos(Transform finder) => DrawSearchArea(finder);

        private void DrawSearchArea(Transform finder)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(finder.position, SearchDistance);
        }

        #endregion

    }
}
