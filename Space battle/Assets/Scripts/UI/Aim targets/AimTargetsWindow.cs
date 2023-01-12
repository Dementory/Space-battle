using System;
using System.Collections.Generic;
using SpaceBattle.Spaceship;
using UnityEngine;
using Zenject;

namespace SpaceBattle.UI
{
    public class AimTargetsWindow : MonoBehaviour
    {
        [SerializeField] private AimTargetsVisualizer _aimTargetsVisualizer;
        [SerializeField] private TargetFinder _targetFinder;
        
        [Inject] private Ship _playersShip;

        private List<Ship> _previoiusTargets = new List<Ship>();

        private void Start() => CheckPresistance();

        private void CheckPresistance()
        {
            if (!_aimTargetsVisualizer) throw new NullReferenceException("Aim targets visualizer isn't assigned");

            if (!_targetFinder) throw new NullReferenceException("Target finder isn't assigned");
        }

        private void Update() => UpdateMarks();

        private void UpdateMarks()
        {
            if (!_playersShip.transform) return;

            List<Ship> targets = _targetFinder.GetAllShipsInSearchArea(_playersShip.transform, _playersShip.TeamMember.Team);
            Ship mainTarget = _targetFinder.FindTarget(_playersShip.transform, _playersShip.TeamMember.Team);

            if (TargetsHasntChanged(targets)) return;

            _previoiusTargets = targets;

            _aimTargetsVisualizer.UpdateAllMarks(targets, mainTarget);
        }

        private bool TargetsHasntChanged(List<Ship> currentTargets) => currentTargets == _previoiusTargets;

    }
}
