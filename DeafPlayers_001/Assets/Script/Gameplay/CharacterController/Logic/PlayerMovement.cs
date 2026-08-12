using System;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    public class PlayerMovement : PlayerComponent
    {
        [SerializeField]
        private CharacterController characterController;
        private bool groundedPlayer;
        
        private Vector3 currentDirection = Vector3.zero ;
        private Vector3 currentVelocity;
        private Vector2 inputDirection;
        
        private float playerSpeed = 5f;
        private float gravityValue =  -9.81f;
        private float stickGrounded = -0.5f; //TODO A SUPPRIMER
        
        private float jumpHeight;
        
        public LayerMask worldLayer;


        
        private void OnEnable()
        {
            if (PlayerController.TryGetFirstComponent(out PlayerControls playerControls))
            {
                playerControls.OnMoveAction += HandleMoveInput;
            }
        }
        private void OnDisable()
        {
            if (PlayerController.TryGetFirstComponent(out PlayerControls playerControls))
            {
                playerControls.OnMoveAction -= HandleMoveInput;
            }
        }
        
        //----------
        
        void FixedUpdate()
        {
            if (characterController.isGrounded && currentVelocity.y < 0)
            {
                currentVelocity.y = stickGrounded;
            }
            
            ApplyMovement();
            ApplyGravity();
        }
        
        private void Update()
        {
            // TODO : Raycast du grounded => a checker si fonctionne
            Ray ray = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(ray, 2, worldLayer, QueryTriggerInteraction.Collide))
            {
                Debug.DrawRay(ray.origin, ray.direction * 2, Color.green);
                Debug.Log("player is grounded");
            }
            Debug.DrawRay(ray.origin, ray.direction * 2, Color.red);
            Debug.Log("player is not grounded");
        }

        
        //---------

        private void HandleMoveInput(Vector2 newInputDirection)
        {
            inputDirection = newInputDirection;
        }
        
        
        private void ApplyMovement()
        {
            currentDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
            characterController.Move(currentDirection * (playerSpeed * Time.deltaTime));
        }
        
        private void ApplyGravity()
        {
            currentVelocity.y += gravityValue * Time.deltaTime;
            characterController.Move(currentVelocity * Time.deltaTime);
        }
    }
}