using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Logic
{
    public class Inventory :  MonoBehaviour
    {
        [SerializeField] private MonoInventoryDisplay display;
        private InventoryData inventoryData;
        
        public void Awake()
        {
            int slotsCount = display.Initialize();
            
            inventoryData = new InventoryData(slotsCount);
            
            display.UpdateDisplay(inventoryData.items);
        }
        public Item AddItem(Item item)
        {
            if (!inventoryData.SlotAvailable(item))
            {
                return item;
            }
            
            inventoryData.AddItem(ref item);
            display.UpdateDisplay(inventoryData.items);
            return item;
        }

        public Item PickItem(int slotID)
        {
            Item result = inventoryData.Pick(slotID);
            display.UpdateDisplay(inventoryData.items);
            return result;
        }
    }
}