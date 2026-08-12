using System.Collections.Generic;
using DeafPlayers.Gameplay.Script.Gameplay.Data;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Logic
{
    public class CardCollection 
    {
        private readonly Card[] currentCollection;

        private readonly Dictionary<CardData, Card> cardCollectionFull;
        
        public CardCollection()
        {
            CardDataBase dataBase = Resources.Load<CardDataBase>("CardDataBase/CardDataBase");
                     
            cardCollectionFull = new();
            currentCollection = new Card[dataBase.CollectionSize];
            
            
             for (int j = 0; j < dataBase.CollectionSize; j++)
             {
                 CardData data = dataBase.DataBase[j];
                 Card card = new Card(data, j);
 
                 cardCollectionFull.TryAdd(data, card);
             }
        }


        public bool TryAddCard(CardData cardData)
        {
            if (!cardCollectionFull.TryGetValue(cardData, out Card card))
            {
                return false;
            }
            
            return TryAddCard(card);
        }
        
        
        public bool TryAddCard(Card card)
        {
            if (currentCollection[card.Index] != null)
            {
                return false;
            }
            
            currentCollection[card.Index] = card;
            
            return true;
        }
        
        
    }
}