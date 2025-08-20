using _Game.Scripts.Application.Events;
using _Game.Scripts.Infrastructure.Messaging;
using _Game.Scripts.Presentation.Roulette.Views;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Presentation.UI.Controls
{
    public class SpinButtonBinder : MonoBehaviour
    {
        private Button spinButton;
        [SerializeField] private RoulettePhysicsSpinner _roulettePhysicsSpinner;
    
        // Called in the editor when the script is loaded or a value changes in the inspector
        private void OnValidate()
        {
            SpinButtonInitialize();
        }

        // Initialize the spin button and set up its click listener
        private void SpinButtonInitialize()
        {
            if(spinButton == null) spinButton = GetComponent<Button>();
        
            spinButton.onClick.RemoveAllListeners();
            spinButton.onClick.AddListener(OnSpinClicked);
        }
        
        // Subscribe to events and initialize button on awake
        private void Awake()
        {
            GlobalBus.Instance.Subscribe<SpinButtonToggleEvent>(OnToggleSpinButton);
            SpinButtonInitialize();

        }

        // Unsubscribe from events to prevent memory leaks
        private void OnDestroy()
        {
            GlobalBus.Instance.Unsubscribe<SpinButtonToggleEvent>(OnToggleSpinButton);
        }

        // Handle toggling the spin button's active state based on event data
        private void OnToggleSpinButton(SpinButtonToggleEvent e)
        {
            if (spinButton != null)
                spinButton.gameObject.SetActive(e.IsActive);
        }
        
        // Called when the spin button is clicked; triggers the roulette spin and disables the button
        public void OnSpinClicked()
        {
            _roulettePhysicsSpinner.Rotete();
            spinButton.gameObject.SetActive(false);
        }
    }
}