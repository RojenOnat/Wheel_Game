using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Presentation.UI.Containers
{
    /// <summary>
    /// UI component representing an item slot, displaying an icon and count for an item.
    /// </summary>
    public class ItemSlotUI : MonoBehaviour
    {
        // Reference to the UI Image component used to display the item's icon.
        [SerializeField] private Image _iconImage;
        // Reference to the UI Text component used to display the item's count.
        [SerializeField] private TMP_Text _countText;

        /// <summary>
        /// Gets the unique identifier for the item in this slot.
        /// </summary>
        public string Id { get; private set; }
        /// <summary>
        /// Gets the current count of the item in this slot.
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Gets the current sprite used as the icon for this item slot.
        /// </summary>
        public Sprite Icon => _iconImage ? _iconImage.sprite : null;

        /// <summary>
        /// Initializes the item slot with the specified id, icon, and count.
        /// </summary>
        /// <param name="id">Unique identifier for the item.</param>
        /// <param name="icon">Sprite to display as the item's icon.</param>
        /// <param name="count">Initial count of the item.</param>
        public void Initialize(string id, Sprite icon, int count)
        {
            Id = id;
            SetIcon(icon);
            SetCount(count);
        }

        /// <summary>
        /// Sets the icon sprite for the item slot.
        /// </summary>
        /// <param name="icon">Sprite to display as the icon.</param>
        public void SetIcon(Sprite icon)
        {
            if (_iconImage) _iconImage.sprite = icon;
        }

        /// <summary>
        /// Sets the count for the item and updates the UI text.
        /// </summary>
        /// <param name="value">New count value.</param>
        public void SetCount(int value)
        {
            Count = value;
            if (_countText) _countText.text = Count.ToString();
        }

        /// <summary>
        /// Increases the item count by the specified amount.
        /// </summary>
        /// <param name="delta">Amount to add to the current count.</param>
        public void AddCount(int delta)
        {
            SetCount(Count + delta);
        }
    }
}