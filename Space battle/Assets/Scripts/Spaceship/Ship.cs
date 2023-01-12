using UnityEngine;

namespace SpaceBattle.Spaceship
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(ShipHealth))]
    public abstract class Ship : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private ITeamMember _teamMember;

        public ITeamMember TeamMember
        {
            get
            {
                if(_teamMember == null)
                    _teamMember = gameObject.GetComponentWithException<ITeamMember>();

                return _teamMember;
            }
        }

        private const float DETECTION_COLLIDER_SIZE = 0.1f;

        #region Initialization

        private void Start() => Initialize();

        protected virtual void Initialize()
        {
            SetUpRigidbody();
            AddDetectionCollider();
        }

        private void SetUpRigidbody()
        {
            _rigidbody = gameObject.GetComponentWithException<Rigidbody>();

            _rigidbody.useGravity = false;
            _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }

        private void AddDetectionCollider()
        {
            BoxCollider detectionCollider = gameObject.AddComponent<BoxCollider>();
            detectionCollider.size = Vector3.one * DETECTION_COLLIDER_SIZE;
        }

        #endregion

    }
}
