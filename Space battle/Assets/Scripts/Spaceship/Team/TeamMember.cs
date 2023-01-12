using SpaceBattle.Battle;
using UnityEngine;

namespace SpaceBattle.Spaceship
{
    public class TeamMember : MonoBehaviour, ITeamMember
    {
        private TeamData _team;
        public TeamData Team => _team;

        public void AssignTeam(TeamData team)
        {
            if (_team != null) return;

            _team = team;

            ITeamDependent[] teamDependents = GetComponents<ITeamDependent>();

            if (teamDependents == null) return;

            foreach (ITeamDependent teamDependent in teamDependents)
                teamDependent.AssignTeam(team);
        }
    }
}
