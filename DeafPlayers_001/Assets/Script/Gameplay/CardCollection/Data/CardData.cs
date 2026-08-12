using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Data
{
    [CreateAssetMenu(menuName = "Gameplay/CardData")]
    public class CardData :  ScriptableObject, IData
    {
        [field : SerializeField]
        public string CardName { get; private set; }
        
        
        [field : SerializeField, TextArea] 
        public string CardDescription { get; private set; }
        
    }
}