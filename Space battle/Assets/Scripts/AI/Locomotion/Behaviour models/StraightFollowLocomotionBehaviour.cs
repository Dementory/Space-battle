using UnityEngine;
using SpaceBattle.Editor;

namespace SpaceBattle.AI
{

    [CreateAssetMenu(fileName = nameof(StraightFollowLocomotionBehaviour), menuName = AIScriptableObjects.LOCOMOTION_BEHAVIOUR_MENU_FOLDER + nameof(StraightFollowLocomotionBehaviour))]
    public class StraightFollowLocomotionBehaviour : LocomotionBehaviour
    {
        private Vector3 _targetDirection;

        public override void Move(Transform movingObject, Transform target, ref Vector2 MoveAxis)
        {
            if (!target)
            {
                MoveAxis = Vector2.zero;
                return;
            }

            _targetDirection = target.position - movingObject.position;

            MoveAxis.x = GetAlligmentMatch(movingObject.forward, movingObject.up);
            MoveAxis.y = -GetAlligmentMatch(movingObject.right, movingObject.forward);
        }

        private float GetAlligmentMatch(Vector3 rotationAxis, Vector3 comparedDirection)
        {
            Vector3 alignDirection = Vector3.Cross(rotationAxis, _targetDirection.normalized);
            float alignmentMatch = Vector3.Dot(alignDirection, comparedDirection);

            return alignmentMatch;
        }
    }
}
