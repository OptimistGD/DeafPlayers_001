using System;
using DeafPlayers.Gameplay.Script.Gameplay.Inventory.Data;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Inventory.Visual
{
    public class MonoInventoryDisplay : MonoBehaviour
    {
        private Slots[] slots;
        
        public int Initialize()
        {
            slots = GetComponentsInChildren<Slots>();

            return slots.Length;
        }
        
        public void UpdateDisplay(Item[] itemData)
        {
            
        }
    }
}