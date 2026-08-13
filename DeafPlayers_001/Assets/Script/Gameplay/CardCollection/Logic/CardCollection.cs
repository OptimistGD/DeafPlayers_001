using System.Collections.Generic;
using DeafPlayers.Gameplay.Script.Gameplay.Data;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Logic
{
    public class CardCollection 
    {
        public Card[] CurrentCollection => currentCollection;
        
        private readonly Card[] currentCollection;

        private readonly Dictionary<CardData, Card> cardCollectionFull;
        
        public CardCollection()
        {
            CardDataBase dataBase = Resources.Load<CardDataBase>("CardDataBase/CardDataBase");
                     
            cardCollectionFull = new();
            currentCollection = new Card[dataBase.CollectionSize];
            
            
             for (int i = 0; i < dataBase.CollectionSize; i++)
             {
                 CardData data = dataBase.DataBase[i];
                 Card card = new Card(data, i);
 
                 cardCollectionFull.TryAdd(data, card);
             }
        }

        //--------------

        public bool TryAddCard(CardData cardData)
        {
            if (!cardCollectionFull.TryGetValue(cardData, out Card card))
            {
                return false;
            }
            
            Debug.Log($"Recherche de : {cardData.name})");
            return TryAddCard(card);
        }

        private bool TryAddCard(Card card)
        {
            if (currentCollection[card.Index] != null)
            {
                Debug.Log("Card already in Collection");
                return false;
            }
            
            currentCollection[card.Index] = card;
            Debug.Log("Card is in Collection");
            
            return true;
        }
    }
}