using System;
using UnityEngine;

namespace Script.Logic
{
    public class PlayerController : MonoBehaviour
    {

        public event Action<Vector3> OnVelocityChange;

        PlayerControls characterControls;
        PlayerCamera playerCamera;
        PlayerMovement playerMovement;
        
        PlayerComponent[] playerComponents;

        internal bool IsGrounded;
        
        void Awake()
        {
            playerComponents = GetComponentsInChildren<PlayerComponent>();
            
            foreach (IPlayerComponent playerComponent in playerComponents)
            {
                playerComponent.Initialize(this);
            }
            
        }
        
        
    }
}
