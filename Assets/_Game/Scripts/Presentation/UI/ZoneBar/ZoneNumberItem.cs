using _Game.Scripts.Infrastructure.Config;
using TMPro;
using UnityEngine;

namespace _Game.Scripts.Presentation.UI.ZoneBar
{
    public class ZoneNumberItem : MonoBehaviour
    {
        // Reference to the UI text component that displays the zone number.
        [SerializeField] private TMP_Text numberText;
        
        // Contains configuration data related to zone levels.
        public ZoneLevelConfigSO ZoneLevelConfigData;

        // The currently assigned zone number value.
        public int Value { get; private set; }

        // Sets the text color to green if the value matches specific configured levels.
        private void SetColorGreen()
        {
            if(Value == ZoneLevelConfigData.SilverRouletteLevel || Value == ZoneLevelConfigData.SilverRouletteLevel) numberText.color = Color.green;
        }
        
        // Sets the zone number value, updates the displayed text, and applies color based on the value.
        public void SetValue(int value)
        {
            Value = value;
            if (numberText) numberText.text = value.ToString();
            SetColorGreen();
        }
    }
}