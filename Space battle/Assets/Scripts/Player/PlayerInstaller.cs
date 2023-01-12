using System;
using SpaceBattle;
using SpaceBattle.Spaceship;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Ship _playerShip;
    [SerializeField] private ShipHealth _playerHealth;

    public override void Start()
    {
        base.Start();

        if (!_playerShip)
            throw new NullReferenceException("Player's ship isn't assigned");

        if (!_playerHealth)
            throw new NullReferenceException("Player's health isn't assigned");
    }

    public override void InstallBindings()
    {
        Container.Bind<Ship>().FromInstance(_playerShip).AsSingle();
        Container.Bind<ShipHealth>().FromInstance(_playerHealth).AsSingle();
    }
}