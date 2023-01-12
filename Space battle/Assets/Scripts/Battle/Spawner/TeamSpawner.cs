using System;
using System.Collections.Generic;
using System.Linq;
using SpaceBattle.Spaceship;
using UnityEngine;

namespace SpaceBattle.Battle
{
    public class TeamSpawner : MonoBehaviour, ITeamSpawner
    {
        [SerializeField] private Ship _playerShip;
        [SerializeField] private SpawnAreaSpawner<Ship> _botShipSpawner;

        private void Start()
        {
            if (!_botShipSpawner)
                throw new NullReferenceException("Bot ship spawner isn't assigned");
        }

        public void SpawnTeam(TeamData teamData, ref List<Team> teams, Action CalculateBattleResults)
        {
            List<Ship> ships = _botShipSpawner.Spawn(teamData.MembersAmount).ToList();

            if (teamData.PlayerIsOnThisTeam)
                ships.Add(_playerShip);

            foreach (Ship ship in ships)
            {
                ship.TeamMember.AssignTeam(teamData);

                if (ship.gameObject.TryGetComponent(out ShipHealth health))
                    health.OnDeath += CalculateBattleResults;
            }

            teams.Add(new Team(teamData, ships.Select(ship => ship.gameObject).ToArray()));
        }
    }
}
