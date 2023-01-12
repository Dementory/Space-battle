using System.Collections.Generic;
using UnityEngine;

namespace SpaceBattle
{
    public interface ISpawner<T> where T : MonoBehaviour
    {
        IEnumerable<T> Spawn(int amount = 1);
    }
}
