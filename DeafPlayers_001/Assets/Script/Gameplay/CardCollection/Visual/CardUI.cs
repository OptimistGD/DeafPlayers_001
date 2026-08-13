using DeafPlayers.Gameplay.Script.Gameplay.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DeafPlayers.Gameplay.Script.Gameplay.Visual
{
    public class CardUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text cardName;
        [SerializeField] private Image cardIcon;
        [SerializeField] private TextMeshPro levelRequired;
        [SerializeField] private TextMeshPro neededCitizen;
        [SerializeField] private TextMeshPro neededHabitation;
        [SerializeField] private TextMeshPro neededField;
        
        
        public void Connect(Card card)
        {
            if (card == null)
                return;
            
            cardName.text = card.CardName;
            cardIcon.sprite = card.CardIcon;
            levelRequired.text = card.LevelRequired.ToString();
            neededCitizen.text = card.NeededCitizen.ToString();
            neededHabitation.text = card.NeededHabitat.ToString();
            neededField.text = card.NeededField.ToString();
            
        }

        public void Disconnect()
        {
            
        }
    }
}