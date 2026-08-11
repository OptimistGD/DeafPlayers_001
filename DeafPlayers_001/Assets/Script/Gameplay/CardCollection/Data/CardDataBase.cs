using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay.Data
{
    [CreateAssetMenu(menuName = "Gameplay/CardDataBase")]
    public class CardDataBase : ScriptableObject
    {
        public int CollectionSize => DataBase.Length;
        
        [field : SerializeField]
        public CardData[] DataBase { get; private set; }
    }
}