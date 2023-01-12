using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceBattle.Input
{
    public class PlayerInputProvider : InputProvider
    {
        private ShipInput _shipInput;

        private Vector2 _moveAxis;

        public override Vector2 MoveAxis => _moveAxis;

        public PlayerInputProvider()
        {
            _shipInput = new ShipInput();

            _shipInput.Default.Enable();

            InitInputValues();
        }

        private void InitInputValues()
        {
            _shipInput.Default.Move.performed += context => { _moveAxis = context.ReadValue<Vector2>(); };
            _shipInput.Default.Move.canceled += context => { _moveAxis = Vector2.zero; };
        }

        public override void OnSecondaryGunShot(Action<InputAction.CallbackContext> OnPress) => _shipInput.Default.ShootAuxiliary.performed += OnPress;

        public override void OnMainGunShot(Action<InputAction.CallbackContext> OnPress) => _shipInput.Default.ShootMain.performed += OnPress;
    }
}
