using System.Collections.Generic;
using UnityEngine;

namespace SpaceBattle.Battle
{
    public class Team
    {
        private TeamData _data;
        private GameObject[] _members;

        public TeamData Data => _data;
        public IEnumerable<GameObject> Members => _members;

        public Team(TeamData teamData, GameObject[] members)
        {
            _data = teamData;
            _members = members;
        }
    }
}
