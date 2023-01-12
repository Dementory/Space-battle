using System.Threading.Tasks;
using UnityEngine;

namespace SpaceBattle.Spaceship
{
    public class AutoAimingBullet : Bullet, ITargetRequester
    {
        [Space]
        [Tooltip("Delay in seconds")]
        [SerializeField] private float _autoAimingActivationDelay;
        [SerializeField] private float _damping;

        public bool HasTarget => _target;

        private Transform _target;
        private Rigidbody _targetRigidbody;

        private bool _isAutoAimingActivated;

        private Vector3 _targetDirection {
            get
            {
                if (HasTarget)
                    return _target.position - transform.position;

                return Vector3.zero;
            }
        }
        private Vector3 _targetVelocity
        {
            get
            {
                if (_targetRigidbody)
                    return _targetRigidbody.velocity;

                return Vector3.zero;
            }
        }

        #region Initialization

        public void AssignTarget(Transform target)
        {
            _target = target;

            if (HasTarget)
                _targetRigidbody = target.GetComponent<Rigidbody>();

            ActivateAutoAimingAfterDelay();
        }

        private async void ActivateAutoAimingAfterDelay()
        {
            await Task.Delay((int)(_autoAimingActivationDelay * 1000));

            _isAutoAimingActivated = true;
        }

        #endregion

        #region Movement

        private void FixedUpdate() => AlignMoveDirectionWithTarget();

        private void AlignMoveDirectionWithTarget()
        {
            if (!HasTarget || !_isAutoAimingActivated) return;

            AlignPosition();
            AlignRotation();
        }

        private void AlignPosition()
        {
            float proportionalGain = Mathf.Pow(6f * MoveSpeed, 2) * 0.25f; 
            float derivativeGain = 4.5f * MoveSpeed * _damping; 
            float g = 1 / (1 + derivativeGain * Time.fixedDeltaTime + proportionalGain * Mathf.Pow(Time.fixedDeltaTime, 2));
            float ksg = proportionalGain * g;
            float kdg = (derivativeGain + proportionalGain * Time.fixedDeltaTime) * g;

            Vector3 force = _targetDirection * ksg + (_targetVelocity - Rigidbody.velocity) * kdg;

            Rigidbody.AddForce(force * 0.1f);
        }

        private void AlignRotation() => transform.rotation = Quaternion.LookRotation(_targetDirection);

        #endregion

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawLine(transform.position, transform.position + transform.forward);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Rigidbody.velocity);
        }

    }
}
