using System;
using SpaceBattle.Battle;
using UnityEngine;
using Zenject;

public class BattleInstigatorInstaller : MonoInstaller
{
    [SerializeField] private BattleInstigator _battleInstigator;

    public override void Start()
    {
        base.Start();

        if (!_battleInstigator)
            throw new NullReferenceException("Battle instigator isn't assigned");
    }

    public override void InstallBindings()
    {
        Container.Bind<BattleInstigator>().FromInstance(_battleInstigator).AsSingle();
    }
}