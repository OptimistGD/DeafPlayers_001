using DeafPlayers.Gameplay.Script.Gameplay.Logic;
using UnityEngine;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    public class MonoItem : MonoBehaviour
    {
        [SerializeField] private Item itemToPush, pickedItem;

        private Logic.Inventory inventory;

        private void Awake()
        {
            inventory = FindObjectOfType<Logic.Inventory>();
            
        }

        [ContextMenu("TestPush")]
        private void Add()
        {
            itemToPush = inventory.AddItem(itemToPush);
        }
        
        [ContextMenu("TestPick")]
        private void Pick()
        {
            pickedItem = inventory.PickItem(1);
            
        }
    }
}