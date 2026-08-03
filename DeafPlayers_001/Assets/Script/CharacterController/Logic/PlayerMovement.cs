using System;
using Script.Visual;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Script.Logic
{
    public class PlayerMovement : PlayerComponent
    {
        MonoPlayerMovement  monoPlayerMovement;
        
        
        private float playerSpeed;
        private float jumpHeight;
        private float gravityValue;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private Vector3 currentVelocity;


        void Update()
        {
            groundedPlayer = playerController.IsGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
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

        
        private void OnEnable()
        {
            moveAction.action.Enable();
            jumpAction.action.Enable();
        }

        private void OnDisable()
        {
            moveAction.action.Disable();
            jumpAction.action.Disable();
        }
        
    }
}