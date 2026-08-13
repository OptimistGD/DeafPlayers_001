using System;
using System.Collections.Generic;
using DeafPlayers.Gameplay.Script.Gameplay.Data;
using DeafPlayers.Gameplay.Script.Gameplay.Logic;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Visual
{
    public class CardCollectionUI : MonoBehaviour
    {
        [SerializeField] 
        private PlayerController playerController;

        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private CardUI cardPrefabUI;
        [SerializeField] private EmptyCardUI emptyCardPrefabUI;
        
        [SerializeField] private Transform container;

        private void Awake()
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }
        //--------

        public void OnEnable()
        {
            if (playerController.TryGetFirstComponent(out PlayerControls playerControls))
            {
                playerControls.OnOpenInventoryAction += ShowUI;
                playerControls.OnOpenInventoryAction += HideUI;
            }
        }

        public void OnDisable()
        {
            if (playerController.TryGetFirstComponent(out PlayerControls playerControls))
            {
                playerControls.OnOpenInventoryAction -= ShowUI;
                playerControls.OnOpenInventoryAction -= HideUI;
            }
        }
        
        //---------

        private void ShowUI()
        {
            RefreshUI();
            
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
        }

        private void HideUI()
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }

        private void RefreshUI()
        {
            Card[] currentCardCollection = playerController.CardCollections.CurrentCollection;
            
            for (int i = 0; i < currentCardCollection.Length; i++)
            {
                Card currentCard = currentCardCollection[i];

                if (currentCard == null)
                {
                    return;
                }
                
                CardUI instance = Instantiate(cardPrefabUI, container);
                instance.Connect(currentCard);
                
            }
        }
    }
}