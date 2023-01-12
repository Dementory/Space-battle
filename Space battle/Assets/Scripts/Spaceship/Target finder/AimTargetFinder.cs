using UnityEngine;
using System.Collections.Generic;
using SpaceBattle.Battle;
using SpaceBattle.Editor;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SpaceBattle.Spaceship
{

    [CreateAssetMenu(fileName = nameof(AimTargetFinder), menuName = WeaponScriptableObjects.TARGET_FINDER_MENU_FOLDER + nameof(AimTargetFinder))]
    public class AimTargetFinder : TargetFinder
    {
        [Range(0, 180)]
        [SerializeField] private float _aimRange;

        public override Ship FindTarget(Transform finder, TeamData team = null)
        {
            List<Ship> shipsInSearchArea = GetAllShipsInSearchArea(finder, team);
            Ship closestShip = GetClosestShip(finder, shipsInSearchArea);

            return closestShip;
        }

        public override List<Ship> GetAllShipsInSearchArea(Transform finder, TeamData team = null)
        {
            List<Ship> shipsInSearchArea = new List<Ship>();
            List<Ship> matchedObjectsInSearchDistance = base.GetAllShipsInSearchArea(finder, team);

            foreach (Ship ship in matchedObjectsInSearchDistance)
            {
                Vector3 shipDirection = ship.transform.position - finder.position;
                float lookAngleToShip = Vector3.Dot(shipDirection, finder.forward) * 360;

                if (lookAngleToShip >= _aimRange)
                    shipsInSearchArea.Add(ship);
            }

            return shipsInSearchArea;
        }

        #region Gizmos

        public override void DrawGizmos(Transform finder) => DrawAimRange(finder);

        private void DrawAimRange(Transform finder)
        {
#if UNITY_EDITOR
            DrawSector(finder, finder.right, finder.up);
            DrawSector(finder, finder.up, -finder.right);
#endif
        }

        private void DrawSector(Transform finder, Vector3 normal, Vector3 limitAxis)
        {
            void DrawLine(Vector3 endPointDirection) => Handles.DrawLine(finder.position, finder.position + endPointDirection * SearchDistance, 6);

            Vector3 startDrawPosition = Vector3.Lerp(finder.forward, limitAxis, _aimRange / 180).normalized;

            Handles.DrawWireArc(finder.position, normal, startDrawPosition, _aimRange, SearchDistance, 6);

            DrawLine(startDrawPosition);
            DrawLine(Vector3.Reflect(startDrawPosition, limitAxis));
        }

        #endregion

    }
}
