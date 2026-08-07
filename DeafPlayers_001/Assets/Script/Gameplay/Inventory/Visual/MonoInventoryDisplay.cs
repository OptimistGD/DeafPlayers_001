using DeafPlayers.Gameplay.Script.Gameplay.Logic;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    public class MonoInventoryDisplay : MonoBehaviour
    {
        private InventorySlot[] slots;
        
        public int Initialize()
        {
            slots = GetComponentsInChildren<InventorySlot>();

            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].Initialize(this, i);
            }

            return slots.Length;
        }
        
        public void UpdateDisplay(Item[] item)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].UpdateDisplay(item[i]);
            }
        }
    }
}