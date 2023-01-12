using System.Collections.Generic;

namespace SpaceBattle.Battle
{
    public interface IBattleResultsCalculator
    {
        void Calculate(List<Team> teamsObjects, out TeamData winnerTeam);
    }
}
