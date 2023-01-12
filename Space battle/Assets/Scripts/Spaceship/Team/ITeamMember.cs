using SpaceBattle.Battle;

namespace SpaceBattle.Spaceship
{
    public interface ITeamMember
    {
        TeamData Team { get; }

        void AssignTeam(TeamData team);
    }
}
