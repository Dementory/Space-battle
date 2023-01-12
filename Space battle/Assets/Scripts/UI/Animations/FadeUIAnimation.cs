using System.Collections;
using UnityEngine;

namespace SpaceBattle.UI
{

    [RequireComponent(typeof(CanvasGroup))]
    public class FadeUIAnimation : UIAnimation
    {
        #region Fields

        [Tooltip("Animation duration in seconds")]
        [SerializeField, Min(0)] private float _duration;

        private CanvasGroup _canvasRenderer;

        #endregion

        #region Initialization

        private void Start() => _canvasRenderer = gameObject.GetComponentWithException<CanvasGroup>();

        #endregion

        public override void Hide() => StartCoroutine(SetActiveCoroutine(false));

        public override void Show() => StartCoroutine(SetActiveCoroutine(true));

        private IEnumerator SetActiveCoroutine(bool enable)
        {
            float frameProgress = Time.deltaTime / _duration;
            frameProgress = enable ? frameProgress : -frameProgress;

            int finalGoal = enable ? 1 : 0;

            if (enable)
                gameObject.SetActive(enable);

            while (_canvasRenderer.alpha != finalGoal)
            {
                _canvasRenderer.alpha += frameProgress;

                yield return new WaitForEndOfFrame();
            }

            if (!enable)
                gameObject.SetActive(enable);

        }

    }
}
