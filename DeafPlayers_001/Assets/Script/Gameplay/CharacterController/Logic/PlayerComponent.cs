using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    public abstract class PlayerComponent : MonoBehaviour, IPlayerComponent
    {
        protected PlayerController playerController;

        protected virtual void Awake()
        {
            playerController = GetComponentInParent<PlayerController>();
            
            playerController.AddComponent(GetType().Name, this);
            
        }
    }
}