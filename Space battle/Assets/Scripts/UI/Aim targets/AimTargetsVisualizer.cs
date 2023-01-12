using System;
using System.Collections.Generic;
using SpaceBattle.Spaceship;
using UnityEngine;

namespace SpaceBattle.UI
{
    public class AimTargetsVisualizer : MonoBehaviour
    {

        #region Fileds

        [SerializeField] private TargetsMarksPool _targetMarksPool;
        [Space]
        [SerializeField] private UnityEngine.Camera _interfaceCamera;

        private List<TargetMark> _targetsMarks = new List<TargetMark>();

        #endregion

        #region Initialization

        private void Start() => CheckCameraPersistance();

        private void CheckCameraPersistance()
        {
            if (!_interfaceCamera)
                throw new NullReferenceException("Interface camera hasn't been assigned");
        }

        #endregion

        private void LateUpdate() => UpdateMarksPosition();

        public void UpdateAllMarks(List<Ship> targets, Ship mainTarget)
        {
            DestroyAllMarks();
            CreateTargetMarks(targets, mainTarget);
        }

        private void DestroyAllMarks()
        {
            foreach (TargetMark targetMark in _targetsMarks)
                _targetMarksPool.Destroy(targetMark);

            _targetsMarks.Clear();
        }

        private void CreateTargetMarks(List<Ship> targets, Ship mainTarget)
        {
            foreach (Ship target in targets)
            {
                TargetMark targetMark = _targetMarksPool.Get();
                targetMark.Target = target.transform;

                if (target.Equals(mainTarget))
                    targetMark.MakeMain();
                else
                    targetMark.MakeNormal();

                _targetsMarks.Add(targetMark);
            }
        }

        private void UpdateMarksPosition()
        {
            foreach (TargetMark targetMark in _targetsMarks)
                targetMark.transform.position = _interfaceCamera.WorldToScreenPoint(targetMark.Target.position);
        }

    }
}
