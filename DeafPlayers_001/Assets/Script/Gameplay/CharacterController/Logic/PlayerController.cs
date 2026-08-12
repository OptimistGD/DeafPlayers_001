using DeafPlayers.Gameplay.Script.Gameplay.Logic;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    public partial class PlayerController : MonoBehaviour
    {
        public CardCollection CardCollections { get; private set; }
        
        
        private void Awake()
        {
            CardCollections = new CardCollection();
        }
        
        
    }
}
