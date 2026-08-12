using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Inventory.Logic
{
    public interface IItemIdentity
    {
        int ID { get; }
        string Name { get; }
        Texture2D SigningImage { get; }
        
        LevelUpStat LevelUpStat { get; }
        int Reputation { get; }
        int CitizenNeeded { get; }
        int HousesNeeded { get; }
        int FieldNeeded { get; }
        
    }
}