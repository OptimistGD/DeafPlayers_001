using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    public abstract class PlayerComponent : MonoBehaviour, IPlayerComponent
    {
        public PlayerController PlayerController {  get; private set; }

        protected virtual void Awake()
        {
            PlayerController = GetComponentInParent<PlayerController>();
            
            PlayerController.AddComponent(GetType().Name, this);

        }
    }
}