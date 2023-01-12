using UnityEngine;

namespace SpaceBattle.Spaceship
{
    public interface ITargetRequester
    {
        bool HasTarget { get; }

        void AssignTarget(Transform target);
    }
}
