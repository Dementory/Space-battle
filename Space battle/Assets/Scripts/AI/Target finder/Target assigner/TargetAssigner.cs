using SpaceBattle.Battle;
using SpaceBattle.Spaceship;
using UnityEngine;

namespace SpaceBattle.AI
{
    public class TargetAssigner : ITargetAssigner
    {
        public void AssignTarget(TargetFinder targetFinder, ITargetRequester[] targetRequesters, Transform finderTransform, TeamData team)
        {
            Ship targetShip = targetFinder.FindTarget(finderTransform, team);
            Transform targetTransform = targetShip ? targetShip.transform : null;

            foreach (ITargetRequester targetRequester in targetRequesters)
            {
                if (targetRequester.HasTarget) continue;

                targetRequester.AssignTarget(targetTransform);
            }
        }
    }
}
