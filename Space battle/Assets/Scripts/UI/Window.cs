using UnityEngine;

namespace SpaceBattle.UI
{
    public class Window : MonoBehaviour
    {
        private UIAnimation _animation;

        protected UIAnimation Animaiton => _animation;

        #region Initialization

        private void Start() => Initialize();

        protected virtual void Initialize() => _animation = gameObject.GetComponentWithException<UIAnimation>();

        #endregion
    }
}
