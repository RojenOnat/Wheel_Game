using _Game.Scripts.Application.Events;
using _Game.Scripts.Infrastructure.Messaging;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Game.Scripts.Presentation.UI.ZoneBar
{
    public class ZooneSlideMono : MonoBehaviour
    {
        // UI elements for displaying and managing zone numbers in the slide bar
        [Header("Hierarchy References")]
        [SerializeField] private RectTransform content;      // Container for zone number items
        [SerializeField] private ZoneNumberItem itemPrefab;  // Prefab for individual zone number item
        [SerializeField] private TextMeshProUGUI _zoneNumberText; // Text displaying the current zone number
    
        // Settings for initial spawning and numbering of zone items
        [Header("Spawn config")]
        [SerializeField] private int initialCount = 5;       // Number of zone items to spawn initially
        [SerializeField] private int startValue   = 1;       // Starting value for zone numbering
        private int _currentValue = 1;                        // Tracks the current zone number
        private int _nextValue;                               // Next zone number to assign to a spawned item

        private void Awake()
        {
            _nextValue = startValue;

            // Spawn the initial set of zone number items
            for (int i = 0; i < initialCount; i++)
                SpawnNext();

            // Subscribe to event that triggers adding new zone numbers
            GlobalBus.Instance.Subscribe<AddZoneNumberEvent>(OnAddZoneNumber);
        }

        private void OnDestroy()
        {
            // Unsubscribe from event to prevent memory leaks
            GlobalBus.Instance.Unsubscribe<AddZoneNumberEvent>(OnAddZoneNumber);
        }

        private void OnAddZoneNumber(AddZoneNumberEvent e)
        {
            // Increment the current zone number and notify other systems of the change
            _currentValue++;
            GlobalBus.Instance.Publish(new ZoneLevelChangedEvent(_currentValue));
        
            // Spawn additional zone number items as specified by the event
            for (int i = 0; i < e.Count; i++)
            {
                SpawnNext();
            }

            // Animate the slide content to the left and update the displayed zone number upon completion
            var currentRectX = content.anchoredPosition.x;
            var goTo = currentRectX - 100;
            content.DOAnchorPosX(goTo, .2f).OnComplete(() =>
            {
                _zoneNumberText.text = _currentValue.ToString();
                // Enable the spin button after animation completes
                GlobalBus.Instance.Publish(new SpinButtonToggleEvent(true));
            });
        }

        private void SpawnNext()
        {
            // Instantiate a new zone number item and assign it the next sequential value
            var item = Instantiate(itemPrefab, content);
            item.SetValue(_nextValue);

            _nextValue += 1;
        }
    }
}
