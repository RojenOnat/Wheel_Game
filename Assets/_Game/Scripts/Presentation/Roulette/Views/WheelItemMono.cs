using _Game.Scripts.Domain;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Presentation.Roulette.Views
{
    public class WheelItemMono : MonoBehaviour
    {
    
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI rewardAmountTMP;

        private WheelItem _data;   // Single reference to wheel item data.

        public void BindData(WheelItem data,Sprite itemSprite)
        {
            _data = data;

            if (icon)  icon.sprite = itemSprite;
            if (rewardAmountTMP) rewardAmountTMP.text = "x" + data.Reward;
        }

        // Public accessors for external usage if needed:
        public string GetId    => _data.Id;
        public string GetName  => _data.Name;
        public int GetReward   => _data.Reward;
        public Sprite GetIcon  => icon.sprite;
    
    }
}
