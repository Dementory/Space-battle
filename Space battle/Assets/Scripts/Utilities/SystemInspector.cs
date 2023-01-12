using System;
using UnityEngine;

namespace SpaceBattle
{
    public static class SystemInspector
    {
        public static T GetComponentWithException<T>(this GameObject gameObject)
        {
            if (!gameObject.TryGetComponent(out T component))
                throw new NullReferenceException($"Can't find a {typeof(T).FullName}");

            return component;
        }
    }
}
