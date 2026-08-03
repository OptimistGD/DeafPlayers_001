using UnityEngine;

namespace Script.Logic
{
    public abstract class PlayerComponent : MonoBehaviour, IPlayerComponent
    {
        protected PlayerController playerController; 
        
        public void Initialize(PlayerController playerController)
        {
            this.playerController = playerController;
        }
    }
}