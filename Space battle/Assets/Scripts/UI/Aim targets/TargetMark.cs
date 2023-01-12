using System;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceBattle.UI
{
    public class TargetMark : MonoBehaviour
    {
        [HideInInspector] public Transform Target;

        [SerializeField] private Image _icon;

        [SerializeField] private Color _normalStateColor;
        [SerializeField] private Color _mainStateColor;

        #region Initialization

        private void Start() => CheckIconPresence();

        private void CheckIconPresence()
        {
            if (!_icon)
                throw new NullReferenceException("Icon hasn't been assigned");
        }

        #endregion

        public void MakeMain() => ChangeColor(_mainStateColor);

        public void MakeNormal() => ChangeColor(_normalStateColor);

        private void ChangeColor(Color color) => _icon.color = color;

    }
}
