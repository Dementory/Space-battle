using SpaceBattle.Battle;
using Zenject;
using SpaceBattle.Spaceship;
using System;

namespace SpaceBattle.UI
{
    public class WinScreen : Window
    {
        [Inject] private Ship _playerShip;

        [Inject] private BattleInstigator _battleInstigator;

        #region Initialization

        protected override void Initialize()
        {
            base.Initialize();

            if (!_playerShip)
                throw new NullReferenceException("Player ship isn't assigned");
        }

        private void OnEnable()
        {
            _battleInstigator.OnBattleEnd += Show;
        }

        private void OnDestroy()
        {
            _battleInstigator.OnBattleEnd -= Show;
        }

        #endregion

        private void Show(TeamData team)
        {
            if (_playerShip.TeamMember.Team == team)
                Animaiton.Show();
        }
    }
}
