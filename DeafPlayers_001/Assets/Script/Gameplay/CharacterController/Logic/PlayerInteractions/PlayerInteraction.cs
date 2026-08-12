using DeafPlayers.Gameplay.Script.Gameplay.Data;
using DeafPlayers.Gameplay.Script.Gameplay.Logic;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.PlayerInteractions
{
    public class PlayerInteraction : PlayerComponent
    {
        [SerializeField] private float sphereSize;

        private IInteractable currentInteractable;
        
        //Buffer
        private Collider[] buffers = new Collider[10];


        
        private void OnEnable()
        {
            if (PlayerController.TryGetFirstComponent(out PlayerControls playerControls))
            {
                playerControls.OnPickupAction += OnInteract;

            }
        }
        private void OnDisable()
        {
            if (PlayerController.TryGetFirstComponent(out PlayerControls playerControls))
            {
                playerControls.OnPickupAction -= OnInteract;

            }
        }
        
        //--------
        
        public void Start()
        {
            if (!PlayerController.TryGetFirstComponent(out PlayerInteraction playerInteraction))
            {
                Debug.LogError("playerInteraction not assigned in BAG");
            }
        }
        
        
        private void FixedUpdate()
        {
            int size = Physics.OverlapSphereNonAlloc(transform.position, sphereSize, buffers);
            for (int i = 0; i < size; i++)
            {
                Collider collider = buffers[i];

                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    currentInteractable = interactable;
                }
            }
        }
        
        //------------
        
        public void OnInteract()
        {
            Debug.Log("Input F is pressed");
            IData data = currentInteractable.Request();

            if (data is CardData cardData)
            {
                PlayerController.CardCollections.TryAddCard(cardData);
            }
        }
    }
}