using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBattle.Battle
{
    public class BattleInstigator : MonoBehaviour
    {
        [SerializeField] private BattleInfo _battleInfo;

        private ITeamSpawner _teamSpawner;
        private IBattleResultsCalculator _battleResultsCalculator = new BattleResultsCalculator();

        private List<Team> _teams = new List<Team>();

        public event Action<TeamData> OnBattleEnd;

        private void Start()
        {
            Initialize();

            StartBattle();
        }

        #region Initialization

        private void Initialize()
        {
            CheckBattleInfo();

            _teamSpawner = gameObject.GetComponentWithException<ITeamSpawner>();
        }

        private void CheckBattleInfo()
        {
            if (!_battleInfo)
            {
                throw new NullReferenceException("Battle info isn't assigned");
            }
            else
            {
                if (_battleInfo.Teams.Count() == 0)
                    print("Battle info doen't contain info about teams");
            }
        }

        #endregion

        #region Battle

        private void StartBattle()
        {
            TeamData[] teams = _battleInfo.Teams.ToArray();

            if (teams == null || teams.Length == 0) return;

            foreach (TeamData team in teams)
                _teamSpawner.SpawnTeam(team, ref _teams, CalculateBattleResults);
        }

        private void CalculateBattleResults()
        {
            _battleResultsCalculator.Calculate(_teams, out TeamData winnerTeam);

            if (winnerTeam == null) return;

            OnBattleEnd(winnerTeam);
        }

        #endregion

    }
    
}
