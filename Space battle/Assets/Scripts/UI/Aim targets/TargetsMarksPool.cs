using System;
using UnityEngine;

namespace SpaceBattle.UI
{
    public class TargetsMarksPool : Pool<TargetMark>
    {
        [SerializeField] private Transform _marksParent;

        #region Initialization

        protected override void Initialize()
        {
            base.Initialize();

            if (!_marksParent)
                throw new NullReferenceException("Marks parent hasn't been assigned");
        }

        #endregion

        protected override TargetMark CreateObject()
        {
            TargetMark targetMark = base.CreateObject();

            targetMark.transform.SetParent(_marksParent);

            return targetMark;
        }

    }
}
