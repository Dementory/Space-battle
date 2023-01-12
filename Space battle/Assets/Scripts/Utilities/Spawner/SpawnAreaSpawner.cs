using System.Collections.Generic;
using UnityEngine;

namespace SpaceBattle
{
    public abstract class SpawnAreaSpawner<T> : MonoBehaviour, ISpawner<T> where T : MonoBehaviour
    {
        [SerializeField] private T _prefab;
        [Space]
        [SerializeField] private SpawnArea[] _spawnAreas;

        public IEnumerable<T> Spawn(int amount = 1)
        {
            List<T> spawnedObjects = new List<T>();
            bool spawnPointsExists = _spawnAreas.Length > 0;

            for (int i = 0; i < amount; i++)
            {
                Vector3 spawnPosition = Vector3.zero;

                if (spawnPointsExists)
                {
                    int spawnPointId = Random.Range(0, _spawnAreas.Length);

                    spawnPosition = _spawnAreas[spawnPointId].GetSpawnPoint();
                }

                GameObject spawnedObject = Instantiate(_prefab.gameObject, spawnPosition, Quaternion.identity);
                spawnedObjects.Add(spawnedObject.GetComponent<T>());
            }

            return spawnedObjects;
        }
    }
}
