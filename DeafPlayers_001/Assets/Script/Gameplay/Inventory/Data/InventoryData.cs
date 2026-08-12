using DeafPlayers.Gameplay.Script.Gameplay.Inventory.Logic;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Inventory
{
    [CreateAssetMenu(menuName = "Gameplay/InventoryData")]
    public class InventoryData : ScriptableObject
    {
         [field : SerializeField] public Item[] Items { get; private set; }
    }
}