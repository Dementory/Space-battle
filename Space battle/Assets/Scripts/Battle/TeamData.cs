using UnityEngine;

namespace SpaceBattle.Battle
{
    [System.Serializable]
    public class TeamData
    {
        [SerializeField] private string _name;
        [SerializeField] private int _membersAmount;
        [Space]
        [SerializeField] private bool _playerIsOnThisTeam;

        public string Name => _name;
        public int MembersAmount => _membersAmount;
        public bool PlayerIsOnThisTeam => _playerIsOnThisTeam;

        public static bool operator ==(TeamData teamA, TeamData teamB)
        {
            if (teamA is null && teamB is null) return true;

            if (teamA is null || teamB is null) return false;

            return teamA.Name == teamB.Name;
        }

        public static bool operator !=(TeamData teamA, TeamData teamB)
        {
            if (teamA is null && teamB is null) return false;

            if (teamA is null || teamB is null) return true;

            return teamA.Name != teamB.Name;
        }

    }
}
