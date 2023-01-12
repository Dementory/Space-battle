using UnityEngine;
using SpaceBattle.Spaceship;

namespace SpaceBattle.AI
{
    public class ShipLocomotionBotBased : ShipLocomotion, ITargetRequester
    {
        #region Fields

        [Space]
        [SerializeField] private LocomotionBehaviour _locomotionBehaviour;

        public bool HasTarget => _target && _target.gameObject.activeSelf;
        private Transform _target;

        #endregion

        private void Update() => _locomotionBehaviour.Move(transform, _target, ref MoveAxis);

        public void AssignTarget(Transform target) => _target = target;

    }
}
