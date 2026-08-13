using DeafPlayers.Gameplay.Script.Gameplay.Data;
using DeafPlayers.Gameplay.Script.Gameplay.Logic;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.PlayerInteractions
{
    public class PlayerInteraction : PlayerComponent
    {
        [SerializeField] private float sphereSize;
        [SerializeField] private LayerMask interactableLayer;
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
        
        private void FixedUpdate()
        {
            int size = Physics.OverlapSphereNonAlloc(transform.position, sphereSize, buffers, interactableLayer, QueryTriggerInteraction.Collide);

            for (int i = 0; i < size; i++)
            {
                Collider collider = buffers[i];
                Debug.Log($"Collider {i} collider : {collider.gameObject.name}");

                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    currentInteractable = interactable;
                }
            }
        }
        //debug => a retirer
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, sphereSize);
        }
        
        //------------
        
        public void OnInteract()
        {
            currentInteractable?.Request(this);
        }
    }
}