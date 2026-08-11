using System;
using DeafPlayers.Gameplay.Script.Gameplay.Logic;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    [CreateAssetMenu(menuName = "Gameplay/InventoryData")]
    public class InventoryData : ScriptableObject
    {
         [field : SerializeField] public Item[] Items { get; private set; }
    }
}