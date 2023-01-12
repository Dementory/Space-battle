using SpaceBattle.Input;
using Zenject;

namespace SpaceBattle.Spaceship
{
    public class ShipLocomotionInputBased : ShipLocomotion
    {
        [Inject]
        private IInputProvider _inputProvider;

        #region Input

        private void Update() => UpdateMoveAxis();

        private void UpdateMoveAxis() => MoveAxis = _inputProvider.MoveAxis;

        #endregion
    }
}
