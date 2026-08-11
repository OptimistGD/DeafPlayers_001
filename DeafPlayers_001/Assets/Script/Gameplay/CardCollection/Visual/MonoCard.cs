using DeafPlayers.Gameplay.Script.Gameplay.Data;
using DeafPlayers.Gameplay.Script.Gameplay.Logic;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Visual
{
    public class MonoCard : MonoBehaviour
    {
        [SerializeField] private CardData cardData;

        public CardData RequestData()
        {
            return cardData;
        }


        /* PAS ICI
        public void blabla()
        {
            var T = new MonoCard();
            CardData cardData = T.RequestData();
            
            CardCollection.TryAddCard(cardData);
        }
        */

    }
}