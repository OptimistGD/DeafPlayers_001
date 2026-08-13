using UnityEngine;


namespace DeafPlayers.Gameplay.Script.Gameplay.Data
{
    [CreateAssetMenu(menuName = "Gameplay/CardData")]
    public class CardData :  ScriptableObject, IData
    {
        [Header("VisibleOnCard")]
        [field : SerializeField]
        public string CardName { get; private set; }
        
        [field : SerializeField]
        public Sprite CardIcon { get; private set; }
        
        [field : SerializeField] 
        public int LevelRequired { get; private set; }
        [field : SerializeField] 
        public int NeededCitizen { get; private set; }
        [field : SerializeField] 
        public int NeededHabitat { get; private set; }
        [field : SerializeField] 
        public int NeededField { get; private set; }
        
        
        [Header("InvisibleOnCard")]
        [field : SerializeField, TextArea] 
        public string CardDescription { get; private set; }
        
    }
}