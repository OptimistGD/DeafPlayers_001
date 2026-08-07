using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    [CreateAssetMenu(menuName = "Gameplay/ItemData")]
    public class ItemData : ScriptableObject
    {
        private string ItemName { get; set; }

        public int StackMaxCount { get; set; }
        public Sprite Icon { get; set; }
        
    }
}