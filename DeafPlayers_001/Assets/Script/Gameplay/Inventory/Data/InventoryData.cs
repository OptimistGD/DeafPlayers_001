using System;
using DeafPlayers.Gameplay.Script.Gameplay.Logic;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    [System.Serializable]
    public class InventoryData
    {
         [field : SerializeField] public Item[] items { get; private set; }

        public InventoryData(int slotCount)
        {
            items = new Item[slotCount];
        }
        
        
         public bool SlotAvailable(Item itemToAdd)
         {
             foreach (var item in items)
             {
                 if (item.AvailableFor(itemToAdd)) 
                 {
                     return true;
                 }
             }
             return false;
         }

         public void AddItem(ref Item itemToAdd)
         {
             for (int i = 0; i < items.Length; i++)
             {
                 if (itemToAdd.Empty)
                 {
                     return;
                 }
                 
                 if (items[i].AvailableFor(itemToAdd))
                 {
                     items[i].MergeOnStack(ref itemToAdd);
                 }
             }
         }

         public Item Pick(int slotID)
         {
             if (slotID > items.Length)
             {
                 throw new SystemException($"ID {slotID} is out of inventory");
             }
             
             Item item = items[slotID];
             items[slotID] = new Item();
             
             return item;
         }
            
    }
}