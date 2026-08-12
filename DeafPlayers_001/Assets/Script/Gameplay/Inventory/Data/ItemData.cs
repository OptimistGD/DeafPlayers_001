using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Inventory
{
    [CreateAssetMenu(menuName = "Gameplay/ItemData")]
    public class ItemData : ScriptableObject
    {
        [field :  SerializeField]
        public string ItemName { get; private set; }
        
        [field :  SerializeField]
        public int StackMaxCount { get; private set; }
        
        [field :  SerializeField]
        public Sprite Icon { get; private set; }
        
    }
}