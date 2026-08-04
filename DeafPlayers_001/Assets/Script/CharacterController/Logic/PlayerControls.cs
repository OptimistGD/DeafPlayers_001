using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Script.Logic
{
    public class PlayerControls : PlayerComponent
    {
        public InputAction moveAction { get; private set; }

        [SerializeField]
        private PlayerInput playerInput;

        

        public Vector2 GetInputDirection(InputAction.CallbackContext context)
        {
            return context.ReadValue<Vector2>();
        }

        private void OnEnable()
        {
            moveAction.Enable();
        }

        private void OnDisable()
        {
            moveAction.Disable();
        }
    }
}