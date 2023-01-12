using System;
using UnityEngine;
using UnityEngine.Pool;

namespace SpaceBattle
{
    public abstract class Pool<T> : MonoBehaviour, IPool<T> where T : MonoBehaviour
    {
        [SerializeField] private T _prefab;

        private ObjectPool<T> _pool;

        private void Start() => Initialize();

        protected virtual void Initialize()
        {
            if (!_prefab) throw new NullReferenceException("Pool prefab is not assigned");

            _pool = new ObjectPool<T>(CreateObject, GetObject, ReleaseObject, DestroyObject, false, 10, 100);
        }

        #region Pool interaciton

        protected virtual T CreateObject() => Instantiate(_prefab);

        protected virtual void GetObject(T poolObject) => poolObject.gameObject.SetActive(true);

        protected virtual void ReleaseObject(T poolObject) => poolObject.gameObject.SetActive(false);

        protected virtual void DestroyObject(T poolObject) => Destroy(poolObject.gameObject);

        #endregion

        public T Get() => _pool.Get();

        public void Destroy(T poolObject) => _pool.Release(poolObject);
    }
}
