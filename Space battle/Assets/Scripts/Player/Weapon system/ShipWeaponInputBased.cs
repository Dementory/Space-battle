using SpaceBattle.Input;
using SpaceBattle.Spaceship;
using Zenject;

namespace SpaceBattle.Player
{
    public class ShipWeaponInputBased : ShipWeapon
    {
        [Inject]
        private IInputProvider _inputProvider;

        #region Initialization

        protected override void Initialize()
        {
            base.Initialize();

            BindExecutionToInput();
        }

        private void BindExecutionToInput()
        {
            _inputProvider.OnMainGunShot(_ => ShootFromMain());
            _inputProvider.OnSecondaryGunShot(_ => ShootFromSecondary());
        }

        #endregion

    }
}
