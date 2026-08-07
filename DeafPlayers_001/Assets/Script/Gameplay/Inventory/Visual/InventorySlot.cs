using DeafPlayers.Gameplay.Script.Gameplay.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DeafPlayers.Gameplay.Script.Gameplay
{
    public class InventorySlot : MonoBehaviour
    {
        private int index;
        
        [SerializeField] private TextMeshProUGUI itemCountText;
        [SerializeField] private Image itemImage;
        
        private MonoInventoryDisplay inventoryDisplay;
        
        public void Initialize(MonoInventoryDisplay currentInventoryDisplay, int currentIndex)
        {
            index = currentIndex;
            inventoryDisplay = currentInventoryDisplay;
            
            itemCountText.text = index.ToString();
        }

        public void UpdateDisplay(Item item)
        {
            if (!item.Empty)
            {
                itemCountText.text = item.Count.ToString();
                itemImage.sprite = item.Data.Icon;
                itemImage.color = Color.white;
                return;
            }

            itemCountText.text = "";
            itemImage.sprite = null;
            itemImage.color = new Color(0, 0, 0, 0);


        }
    }
}