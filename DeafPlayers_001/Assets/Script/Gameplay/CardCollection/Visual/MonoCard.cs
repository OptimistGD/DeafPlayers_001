using DeafPlayers.Gameplay.Script.Gameplay.Data;
using DeafPlayers.Gameplay.Script.Gameplay.Logic;
using DeafPlayers.Gameplay.Script.Gameplay.PlayerInteractions;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Visual
{
    public class MonoCard : MonoBehaviour, IInteractable
    {
        [SerializeField] private CardData cardData;
        
        public IData Request()
        {
            return cardData;
        }
    }
}