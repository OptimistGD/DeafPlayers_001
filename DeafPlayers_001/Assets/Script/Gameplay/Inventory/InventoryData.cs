namespace DeafPlayers.Gameplay.Script.Gameplay.Inventory
{
    public class InventoryData
    {
         public Item[] items { get; private set; }

        public InventoryData(int slotCount)
        {
            items = new Item[slotCount];
        }
        
        
         public bool SlotAvailable(Item itemData)
         {
             throw  new System.NotImplementedException();
         }

         public Item AddItem(Item itemData)
         {
             throw  new System.NotImplementedException();
         }

         public Item Pick(int slotID)
         {
             throw  new System.NotImplementedException();
         }
            
    }
}