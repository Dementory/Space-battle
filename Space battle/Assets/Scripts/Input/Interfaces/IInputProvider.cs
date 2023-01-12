using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceBattle.Input
{
    public interface IInputProvider
    {
        Vector2 MoveAxis { get; }

        void OnMainGunShot(Action<InputAction.CallbackContext> OnPress);

        void OnSecondaryGunShot(Action<InputAction.CallbackContext> OnPress);
    }
}
