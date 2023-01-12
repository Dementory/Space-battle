using UnityEngine;

namespace SpaceBattle.Camera
{
    public class FollowingCamera : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [Space]
        [SerializeField] private Vector3 _positionOffset;
        [SerializeField] private Vector2 _lookOffset;

        [Min(0)]
        [SerializeField] private float _rotationSpeed;

        [Min(0)]
        [SerializeField] private float _moveSpeed;

        #region Motion

        void Update()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            Vector3 targetPosition = _target.TransformPoint(_positionOffset);

            transform.position = Vector3.Slerp(transform.position, targetPosition, _moveSpeed * Time.deltaTime);
        }

        private void Rotate()
        {
            Vector3 lookPoint = _target.TransformPoint(new Vector3(_lookOffset.x, _lookOffset.y, 0));
            Vector3 lookDirection = lookPoint - transform.position;

            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(lookDirection, _target.up),
                _rotationSpeed * Time.deltaTime);
        }

        #endregion

    }
}
