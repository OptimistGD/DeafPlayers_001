using System;
using DeafPlayers.Gameplay.Script.Gameplay.PlayerInteractions;
using Gameplay.CharacterController.Controls;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    public class PlayerControls : PlayerComponent
    {
        public PlayerInputActions InputActions { get; private set; }
        
        public event Action<Vector2> OnMoveAction;
        public event Action OnPickupAction;
        
        
        protected override void Awake()
        {
            base.Awake();
            InputActions = new PlayerInputActions();
        }
        

        private void OnEnable()
        {
            //Enable MOVE
            //performed => input pressed -- canceled => input relaché 
            InputActions.Gameplay.Move.performed += GetInputDirection;
            InputActions.Gameplay.Move.canceled += GetInputDirection;
            InputActions.Gameplay.Move.Enable();
            
            //Enable PICKCARD
            InputActions.Gameplay.PickCard.performed += GetPickupInput;
            InputActions.Gameplay.PickCard.Enable();

        }

        private void OnDisable()
        {
            //Disable MOVE
            InputActions.Gameplay.Move.performed -= GetInputDirection;
            InputActions.Gameplay.Move.canceled -= GetInputDirection;
            InputActions.Gameplay.Move.Disable();
            
            //Disable PICKCARD
            InputActions.Gameplay.PickCard.performed -= GetPickupInput;
            InputActions.Gameplay.PickCard.Disable();
        }

        
        
        public void GetInputDirection(InputAction.CallbackContext context)
        {
            OnMoveAction?.Invoke(context.ReadValue<Vector2>());
        }
        
        private void GetPickupInput(InputAction.CallbackContext context)
        {
            OnPickupAction?.Invoke();
            
            if (PlayerController.TryGetFirstComponent(out PlayerInteraction playerInteraction))
            {
                playerInteraction.OnInteract();
            }
        }
        
    }
}