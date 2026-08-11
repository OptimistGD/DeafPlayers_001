using DeafPlayers.Gameplay.Script.Gameplay.Data;

namespace DeafPlayers.Gameplay.Script.Gameplay.Logic
{
    public class Card
    {
        public int Index { get; private set; }
        

        public Card(CardData cardData, int index)
        {
            Index = index;
        }
    }
}