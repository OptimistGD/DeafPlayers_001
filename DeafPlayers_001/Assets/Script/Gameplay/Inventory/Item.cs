using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Inventory
{
    [System.Serializable]
    public struct Item : IItemIdentity
    {
        [Header("ItemData")]
        [SerializeField] private int countOnSlot;
        [SerializeField] private ItemData items;
        
        [Header("ItemIdentity")]
        [field: SerializeField] public int ID { get; }
        [field: SerializeField] public string Name { get; }
        [field: SerializeField] public Texture2D SigningImage { get; }
        [field: SerializeField] public LevelUpStat LevelUpStat { get; }
        [field: SerializeField] public int Reputation { get; }
        [field: SerializeField] public int CitizenNeeded { get; }
        [field: SerializeField] public int HousesNeeded { get; }
        [field: SerializeField] public int FieldNeeded { get; }
    }
}