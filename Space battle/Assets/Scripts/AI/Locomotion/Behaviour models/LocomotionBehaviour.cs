using UnityEngine;

namespace SpaceBattle.AI
{
    public abstract class LocomotionBehaviour : ScriptableObject
    {
        public abstract void Move(Transform movingObject, Transform target, ref Vector2 MoveAxis);
    }
}
