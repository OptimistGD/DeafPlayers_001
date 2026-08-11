using System.Collections.Generic;
using DeafPlayers.Gameplay.Script.Gameplay.Data;

namespace DeafPlayers.Gameplay.Script.Gameplay.Logic
{
    public class CardCollection
    {
        private readonly Card[] collection;

        private CardCollection(CardDataBase cardDataBase)
        {
            collection = new Card[cardDataBase.CollectionSize];
        }

        public bool TryAddCard(Card card)
        {
            if (collection[card.Index] != null)
            {
                return false;
            }
            
            collection[card.Index] = card;
            
            return true;
        }
        
        
    }
}