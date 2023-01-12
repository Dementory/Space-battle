using System;
using UnityEngine;

namespace SpaceBattle.AI
{
    public abstract class ShootBehaviour : ScriptableObject
    {
        public abstract void Shoot(Transform shootingEntity, Transform target, Action ShootFromMain, Action ShootFromSecondary);  
    }
}
