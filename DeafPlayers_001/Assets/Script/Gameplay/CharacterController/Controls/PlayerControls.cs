using System;
using DeafPlayers.Gameplay.Script.Gameplay.PlayerInteractions;
using DeafPlayers.Gameplay.Script.Gameplay.Visual;
using Gameplay.CharacterController.Controls;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    public class PlayerControls : PlayerComponent, PlayerInputActions.IGameplayActions
    {
        public PlayerInputActions InputActions { get; private set; }
        
        public event Action<Vector2> OnMoveAction;
        public event Action OnPickupAction;
        public event Action OnOpenInventoryAction;
        
        
        protected override void Awake()
        {
            base.Awake();
            InputActions = new PlayerInputActions();
        }
        
        //------------

        private void OnEnable()
        {
            //Enable MOVE
            //performed => input pressed -- canceled => input relaché 
            InputActions.Gameplay.Move.performed += OnMove;
            InputActions.Gameplay.Move.canceled += OnMove;
            InputActions.Gameplay.Move.Enable();
            
            //Enable PICKCARD
            InputActions.Gameplay.PickCard.performed += OnPickup;
            InputActions.Gameplay.PickCard.Enable();

        }

        private void OnDisable()
        {
            //Disable MOVE
            InputActions.Gameplay.Move.performed -= OnMove;
            InputActions.Gameplay.Move.canceled -= OnMove;
            InputActions.Gameplay.Move.Disable();
            
            //Disable PICKCARD
            InputActions.Gameplay.PickCard.performed -= OnPickup;
            InputActions.Gameplay.PickCard.Disable();
        }

        //---------------
        
        
        public void OnMove(InputAction.CallbackContext context)
        {
            OnMoveAction?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnPickup(InputAction.CallbackContext context)
        {
            OnPickupAction?.Invoke();
            
            if (PlayerController.TryGetFirstComponent(out PlayerInteraction playerInteraction))
            {
                playerInteraction.OnInteract();
            }
        }

        public void OnOpenInventory(InputAction.CallbackContext context)
        {
            OnOpenInventoryAction?.Invoke();
            
            //TODO : trouver une méthode pour checker si l'inventaire est deja ouvert ou pas => positif//negatif ???
        }
    }
}