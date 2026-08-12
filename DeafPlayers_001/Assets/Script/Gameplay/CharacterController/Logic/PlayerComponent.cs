using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    public abstract class PlayerComponent : MonoBehaviour, IPlayerComponent
    {
        protected PlayerController PlayerController;

        protected virtual void Awake()
        {
            PlayerController = GetComponentInParent<PlayerController>();
            
            PlayerController.AddComponent(GetType().Name, this);
            
        }
    }
}