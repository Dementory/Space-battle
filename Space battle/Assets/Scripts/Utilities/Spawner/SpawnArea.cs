using UnityEngine;

namespace SpaceBattle
{
    public class SpawnArea : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _spawnRange;

        public Vector3 GetSpawnPoint() => transform.position + Random.insideUnitSphere * _spawnRange;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _spawnRange);
        }
    }
}
