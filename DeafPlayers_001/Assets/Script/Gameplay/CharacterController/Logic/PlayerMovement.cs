using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    public class PlayerMovement : PlayerComponent
    {
        PlayerControls playerControls;
        
        [SerializeField]
        private CharacterController characterController;
        private bool groundedPlayer;
        
        [Header ("Calculate Velocity")]
        private Vector3 currentDirection;
        [SerializeField]
        private float playerSpeed;
        private float strenght;
        private Vector3 currentPlayerVelocity;
        
        [Header ("Calculate Jump")]
        [SerializeField]
        private float jumpHeight;
        private float gravityValue =  -9.81f;
        
        

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            if (!playerController.TryGetFirstComponent(out playerControls))
            {
                Debug.LogError("playerControls not assigned in BAG");
            }
            
            ApplyGravity();
        }

        public LayerMask worldLayer;

        private void Update()
        {
            
            Ray ray = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(ray, 2, worldLayer, QueryTriggerInteraction.Collide))
            {
                Debug.DrawRay(ray.origin, ray.direction * 2, Color.green);
                Debug.Log("player is grounded");
            }
            Debug.DrawRay(ray.origin, ray.direction * 2, Color.red);
            Debug.Log("player is not grounded");
        }

        void FixedUpdate()
        {
            groundedPlayer = characterController.isGrounded;
            if (groundedPlayer && currentPlayerVelocity.y < 0)
            {
                currentPlayerVelocity.z = 0f;
            }
            
            
            ComputeMovement();
            ComputeJump();
        }

        private void ComputeMovement()
        {
            GetPlayerDirection();
            GetPlayerVelocity();
            
            characterController.Move(currentDirection * (playerSpeed * Time.deltaTime));
        }
        
        private void ComputeJump()
        {
            if (playerControls.JumpAction.triggered && groundedPlayer)
            {
                bool inputJump = playerControls.GetInputJump();
                
                currentPlayerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
                Debug.Log("player jump");
            }
            Debug.Log("player not jump");
            
        }

        private void GetPlayerDirection()
        {
            Vector2 inputDirection = playerControls.GetInputDirection();
            currentDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
            //Debug.Log($"Direction {currentDirection}");
        }
        
        private void ApplyGravity()
        {
            currentPlayerVelocity.y += gravityValue * Time.deltaTime;
            //Debug.Log($"Gravity {currentPlayerVelocity}");
        }
        
        private void GetPlayerVelocity()
        {
            Vector3 finalPlayerVelocity = currentDirection * playerSpeed + (currentPlayerVelocity.y * Vector3.up);
            currentPlayerVelocity += finalPlayerVelocity;
            //Debug.Log($"Velocity {finalPlayerVelocity}");
        }
        
        
        
        
    }
}