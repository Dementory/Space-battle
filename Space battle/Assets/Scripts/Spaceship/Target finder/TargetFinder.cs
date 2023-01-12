using System.Collections.Generic;
using SpaceBattle.Battle;
using UnityEngine;

namespace SpaceBattle.Spaceship
{
    public abstract class TargetFinder : ScriptableObject
    {

        #region Fields

        [SerializeField] protected float SearchDistance;

        #endregion

        public abstract Ship FindTarget(Transform finder, TeamData team = null);

        public virtual List<Ship> GetAllShipsInSearchArea(Transform finder, TeamData team = null)
        {
            Collider[] objectsInSearchArea = Physics.OverlapSphere(finder.position, SearchDistance);
            List<Ship> shipsInSearchArea = new List<Ship>();

            foreach (Collider objectInSearchArea in objectsInSearchArea)
            {
                if (IsPotentialTarget(objectInSearchArea, out Ship ship, finder))
                {
                    TeamData shipTeam = ship.TeamMember.Team;

                    if (team == null || shipTeam == null || shipTeam != team)
                        shipsInSearchArea.Add(ship);
                }
            }

            return shipsInSearchArea;
        }

        protected Ship GetClosestShip(Transform finder, List<Ship> shipsInSearchArea)
        {
            Ship closestShip = null;
            float distanceToClosestShip = 0;

            foreach (Ship ship in shipsInSearchArea)
            {
                float distanceToShip = Vector3.Distance(ship.transform.position, finder.position);

                if (closestShip == null || distanceToClosestShip > distanceToShip)
                {
                    closestShip = ship;
                    distanceToClosestShip = distanceToShip;
                }
            }

            return closestShip;
        }

        protected bool IsPotentialTarget(Collider objectInSearchArea, out Ship ship, Transform finder)
        {
            ship = null;

            return objectInSearchArea.gameObject != finder.gameObject && objectInSearchArea.gameObject.activeSelf && objectInSearchArea.TryGetComponent(out ship);
        }

        public virtual void DrawGizmos(Transform finder){}

    }
}
