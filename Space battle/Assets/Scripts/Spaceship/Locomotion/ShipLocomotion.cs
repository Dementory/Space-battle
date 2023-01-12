using SpaceBattle.Utilities;
using UnityEngine;

namespace SpaceBattle.Spaceship
{

    [RequireComponent(typeof(Rigidbody))]
    public abstract class ShipLocomotion : MonoBehaviour, IResponsiveToDeath
    {
        #region Fields

        [Header("Movement")]

        [Tooltip("Move acceleration in km/h")]
        [SerializeField] private float _moveAcceleration;
        [Tooltip("Max move speed in km/h")]
        [SerializeField] private float _maxMoveSpeed;

        [Header("Rotation")]

        [SerializeField] private float _pitchSpeed;
        [SerializeField] private float _rollSpeed;
        [SerializeField] private float _rotationDamping;

        private Rigidbody _rigidbody;
        protected Vector2 MoveAxis;

        private bool _isDead;

        #endregion

        #region Initialization

        private void Start() => Initialize();

        protected virtual void Initialize() => _rigidbody = gameObject.GetComponentWithException<Rigidbody>();

        #endregion

        #region Movement

        private void FixedUpdate()
        {
            if (_isDead) return;

            Move();
            Rotate();
        }

        private void Move()
        {
            _rigidbody.velocity += transform.forward
                * UnitConverter.FromKilometersPerHourToMetersPerSecond(_moveAcceleration)
                * Time.fixedDeltaTime;

            LimitMoveSpeed();
        }

        private void LimitMoveSpeed()
        {
            float maxMoveSpeedInMetersPerSecond = UnitConverter.FromKilometersPerHourToMetersPerSecond(_maxMoveSpeed);
            if (_rigidbody.velocity.magnitude > maxMoveSpeedInMetersPerSecond)
                _rigidbody.velocity = _rigidbody.velocity.normalized * maxMoveSpeedInMetersPerSecond;
        }

        private void Rotate()
        {
            RotateByAxis(-MoveAxis.x, _rollSpeed, transform.forward);
            RotateByAxis(MoveAxis.y, _pitchSpeed, transform.right);

            DampRotation();
        }

        private void RotateByAxis(float inputAxis, float speed, Vector3 rotationAxis) => _rigidbody.angularVelocity += inputAxis * speed * rotationAxis * Time.fixedDeltaTime;

        private void DampRotation() => _rigidbody.angularVelocity -= _rigidbody.angularVelocity * _rotationDamping * Time.fixedDeltaTime;

        #endregion

        public void OnDeath() => _isDead = true;

    }
}
