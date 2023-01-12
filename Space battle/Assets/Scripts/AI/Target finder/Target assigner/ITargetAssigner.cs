using SpaceBattle.Battle;
using SpaceBattle.Spaceship;
using UnityEngine;

namespace SpaceBattle.AI
{
    public interface ITargetAssigner
    {
        void AssignTarget(TargetFinder targetFinder, ITargetRequester[] targetRequesters, Transform finderTransform, TeamData team);
    }
}
