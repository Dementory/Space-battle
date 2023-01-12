using UnityEngine;

namespace SpaceBattle.Spaceship
{
    [System.Serializable]
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Transform[] BulletSpawnPoints;
        [Space]
        [Header("Propperties")]
        [SerializeField, Min(0)] private float _damage;

        public abstract void Fire(Transform aimTarget = null);
    }
}
