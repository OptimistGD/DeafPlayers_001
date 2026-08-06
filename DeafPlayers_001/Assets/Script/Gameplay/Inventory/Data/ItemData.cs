using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Inventory.Data
{
    [CreateAssetMenu(menuName = "Gameplay/ItemData")]
    public class ItemData : ScriptableObject
    {
        public int stackMaxCount = 1;
    }
}