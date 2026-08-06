using System;
using DeafPlayers.Gameplay.Script.Gameplay.Inventory.Data;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Inventory
{
    [System.Serializable]
    public struct Item : IItemIdentity
    {
        [Header("ItemData")]
        [SerializeField] private int currentCountStack;
        [SerializeField] private ItemData data;
        
        [Header("ItemIdentity")]
        [field: SerializeField] public int ID { get; }
        [field: SerializeField] public string Name { get; }
        [field: SerializeField] public Texture2D SigningImage { get; }
        [field: SerializeField] public LevelUpStat LevelUpStat { get; }
        [field: SerializeField] public int Reputation { get; }
        [field: SerializeField] public int CitizenNeeded { get; }
        [field: SerializeField] public int HousesNeeded { get; }
        [field: SerializeField] public int FieldNeeded { get; }

        public bool AvailableFor(Item other) => Empty || (Data == other.data && !Full);
        public ItemData Data => data;
        public bool Full => data && currentCountStack >= data.stackMaxCount;
        public bool Empty => currentCountStack == 0 || data  == null;

        public void MergeOnStack(ref Item newItems)
        {
            if (Full)
            {
                return;
            }

            if (Empty)
            {
                data = newItems.Data;
            }

            if (newItems.data != data)
            {
                throw new SystemException("try to merge differents types if items");
            }
            
            //total = new items + the old one
            int currentTotal = newItems.currentCountStack + currentCountStack;

            //if total < the max of current item, old stack = total && new items = 0 (transfert de data)
            if (currentTotal <= data.stackMaxCount)
            {
                currentCountStack = currentTotal;
                newItems.currentCountStack = 0;
                Debug.Log("items is added");
                return;
            }
            
            //if total max or equals the max of the item's stack, the stack is full && return the difference / reste
            currentCountStack = data.stackMaxCount;
            newItems.currentCountStack = currentTotal - currentCountStack;
            Debug.Log("items is not added");
        }
        
        


    }
}