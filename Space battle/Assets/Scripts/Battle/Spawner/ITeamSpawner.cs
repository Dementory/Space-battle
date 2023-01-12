using System;
using System.Collections.Generic;

namespace SpaceBattle.Battle
{
    public interface ITeamSpawner
    {
        void SpawnTeam(TeamData team, ref List<Team> teamsObjects, Action CalculateBattleResults);
    }
}
