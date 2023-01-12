using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceBattle.Input
{
    public abstract class InputProvider : IInputProvider
    {
        public abstract Vector2 MoveAxis { get; }

        public abstract void OnSecondaryGunShot(Action<InputAction.CallbackContext> OnPress);

        public abstract void OnMainGunShot(Action<InputAction.CallbackContext> OnPress);
    }
}
