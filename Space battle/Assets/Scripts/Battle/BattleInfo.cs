using UnityEngine;
using System.Collections.Generic;

namespace SpaceBattle.Battle
{

    [CreateAssetMenu(fileName = "BattleInfo", menuName = "Info/Battle")]
    public class BattleInfo : ScriptableObject
    {
        [SerializeField] private TeamData[] _teams;

        public IEnumerable<TeamData> Teams => _teams;
    }
}
