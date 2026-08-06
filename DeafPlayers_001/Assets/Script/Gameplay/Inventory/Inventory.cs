using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Inventory
{
    public class Inventory :  MonoBehaviour
    {
        [SerializeField] private MonoInventoryDisplay display;
        private InventoryData data;
        
        private void Awake()
        {
            int slotCount = display.Initialize();
            
            data = new InventoryData(slotCount);
            
        }

        public Item AddItem(Item item)
        {
            if (!data.SlotAvailable(item))
            {
                return item;
            }
            
            item = data.AddItem(item);
            display.UpdateDisplay(data.items);
            return item;
        }

        public Item PickItem(int slotID)
        {
            Item result = data.Pick(slotID);
            display.UpdateDisplay(data.items);
            return result;
        }
    }
}