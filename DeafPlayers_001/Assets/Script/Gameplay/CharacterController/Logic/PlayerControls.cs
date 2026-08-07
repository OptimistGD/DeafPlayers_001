using Gameplay.CharacterController.Controls;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    public class PlayerControls : PlayerComponent
    {
        
        private PlayerInputActions PlayerInputActions { get; set; }
        public InputAction MoveAction => PlayerInputActions.Gameplay.Move;
        public InputAction JumpAction => PlayerInputActions.Gameplay.Jump;
        public InputAction OpenInventory => PlayerInputActions.Gameplay.OpenInventory;

        
        
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

        public bool GetInputJump()
        {
            return JumpAction.ReadValue<bool>();
        }

        public bool GetOpenInventoryButton()
        {
            return OpenInventory.ReadValue<bool>();
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