using System;
using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

namespace SpaceBattle.Visual
{
    public class ParticleEffect : MonoBehaviour
    {
        [SerializeField] private VisualEffect _particleEffect;
        [SerializeField] private float _duration;

        private Action Destroy;

        private void Start()
        {
            if (Destroy == null)
                Destroy = () => MonoBehaviour.Destroy(gameObject);
        }

        public void StopAfterDelay() => StartCoroutine(StopAfterDelayCoroutine());

        private IEnumerator StopAfterDelayCoroutine()
        {
            yield return new WaitForSeconds(_duration);

            Stop();
        }

        private void Stop()
        {
            _particleEffect.Stop();

            Destroy();
        }

        public void OverrideDestroy(Action OverrideDestroy) => Destroy = OverrideDestroy;

    }
}
