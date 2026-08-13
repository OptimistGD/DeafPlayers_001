using DeafPlayers.Gameplay.Script.Gameplay.Data;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Logic
{
    public class Card
    {
        public int Index { get; private set; }
        public string CardName { get; private set; }
        public Sprite CardIcon { get; private set; }
        public int LevelRequired { get; private set; }
        public int NeededCitizen { get; private set; }
        public int NeededHabitat { get; private set; }
        public int NeededField {get ; private set;}

        public Card(CardData cardData, int index)
        {
            Index = index;
            CardName = cardData.CardName;
            CardIcon = cardData.CardIcon;
            LevelRequired = cardData.LevelRequired;
            NeededCitizen = cardData.NeededCitizen;
            NeededHabitat = cardData.NeededHabitat;
            NeededField = cardData.NeededField;

        }
    }
}