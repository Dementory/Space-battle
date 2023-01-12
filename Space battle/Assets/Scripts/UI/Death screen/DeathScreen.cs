using Zenject;

namespace SpaceBattle.UI
{
    public class DeathScreen : Window
    {
        [Inject] private ShipHealth _shipHealth;

        #region Initialization

        private void OnEnable()
        {
            _shipHealth.OnDeath += Show;
        }

        private void OnDestroy()
        {
            _shipHealth.OnDeath -= Show;
        }

        #endregion

        private void Show() => Animaiton.Show();

    }
}
