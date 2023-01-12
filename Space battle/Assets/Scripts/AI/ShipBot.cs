using System;
using SpaceBattle.Spaceship;
using UnityEngine;

namespace SpaceBattle.AI
{
    public class ShipBot : Ship
    {

        #region Fields

        [SerializeField] private TargetFinder _targetFinder;
        private ITargetRequester[] _targetRequesters;

        private ITargetAssigner _targetAssigner;

        #endregion

        #region Initialization

        protected override void Initialize()
        {
            base.Initialize();

            _targetAssigner = new TargetAssigner();

            CheckTargetFinderPresence();
            AssignTargetRequester();
        }

        private void CheckTargetFinderPresence()
        {
            if (_targetFinder == null) throw new NullReferenceException("Target finder isn't assigned");
        }

        private void AssignTargetRequester()
        {
            _targetRequesters = GetComponents<ITargetRequester>();

            if (_targetRequesters == null) throw new NullReferenceException("Can't find target requester");
        }

        #endregion

        private void Update() => _targetAssigner.AssignTarget(_targetFinder, _targetRequesters, transform, TeamMember.Team);

    }
}
