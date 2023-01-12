using System.Collections.Generic;
using System.Linq;

namespace SpaceBattle.Battle
{
    public class BattleResultsCalculator : IBattleResultsCalculator
    {
        public void Calculate(List<Team> teams, out TeamData winnerTeam)
        {
            Team[] survivedTeams = teams.Where(team => team.Members.Any(member => member.gameObject.activeSelf)).ToArray();
            
            if (survivedTeams.Length > 1 || survivedTeams.Length == 0)
            {
                winnerTeam = null;
                return;
            }

            winnerTeam = survivedTeams.Where(teamObjects => teamObjects.Members.Count() > 0)
                .Select(teamObjects => teamObjects.Data).Single();
        }
    }
}
