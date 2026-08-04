using System;
using Script.Visual;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Script.Logic
{
    public class PlayerMovement : PlayerComponent
    {
        MonoPlayerMovement  monoPlayerMovement;
        
        [SerializeField]
        private CharacterController characterController;

        [SerializeField]
        private float playerSpeed;
        
        private float jumpHeight;
        private float gravityValue;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private Vector3 currentVelocity;
        

        void Update()
        {
            groundedPlayer = characterController.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            
            ComputeMovement();
        }

        public void ComputeMovement()
        {
            Debug.Log($"Direction {playerController.Direction}");
            characterController.Move(playerController.Direction * (playerSpeed * Time.deltaTime));
        }

        private Vector3 GetDirection()
        {
            Vector2 input = monoPlayerMovement.moveAction.action.ReadValue<Vector2>();
            currentVelocity = new Vector3(input.x, 0, input.y);
            currentVelocity = Vector3.ClampMagnitude(currentVelocity, 1f);
            return currentVelocity;
        }

        private void GetJumpVelocity()
        {
            if (monoPlayerMovement.jumpAction.action.triggered && groundedPlayer)
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
            }
        }

        private void ApplyGravity()
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
        }

        private void GetPlayerVelocity()
        {
            Vector3 finalVelocity = GetDirection() * playerSpeed + (playerVelocity.y * Vector3.up);
            playerVelocity += finalVelocity;
        }
        
        
    }
}