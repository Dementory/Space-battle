using UnityEngine;

namespace SpaceBattle.Spaceship
{
    public class TargetFindersGizmosDrawer : MonoBehaviour
    {
        [SerializeField] private TargetFinder[] _targetFinders;

        private void OnDrawGizmosSelected()
        {
            if (_targetFinders == null || _targetFinders.Length == 0) return;

            foreach (TargetFinder targetFinder in _targetFinders)
            {
                if (!targetFinder) continue;

                targetFinder.DrawGizmos(transform);
            }
        }
    }
}
