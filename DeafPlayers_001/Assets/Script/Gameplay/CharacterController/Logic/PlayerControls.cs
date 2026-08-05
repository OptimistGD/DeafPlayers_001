using System;
using Gameplay.CharacterController.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Script.Logic
{
    public class PlayerControls : PlayerComponent
    {
        
        public InputAction MoveAction => PlayerInputActions.Gameplay.Move;
        public InputAction JumpAction => PlayerInputActions.Gameplay.Jump;
        
        public PlayerInputActions PlayerInputActions { get; private set; }
        
        
        /// <summary>
        /// ///////
        /// </summary>
        
        protected override void Awake()
        {
            base.Awake();
            PlayerInputActions = new PlayerInputActions();
        }


        public Vector2 GetInputDirection()
        {
            return MoveAction.ReadValue<Vector2>();
        }

        public Vector3 GetInputJump()
        {
            return JumpAction.ReadValue<Vector3>();
        }
        
        
        /// <summary>
        /// /////////////////
        /// </summary>
        
        private void OnEnable()
        {
            PlayerInputActions.Enable();
        }

        private void OnDisable()
        {
            PlayerInputActions.Disable();
        }
    }
}