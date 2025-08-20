using UnityEngine;

namespace _Game.Scripts.Application.Events
{
    /// <summary>
    /// Event data structure used to show a card popup with specific details.
    /// </summary>
    public readonly struct ShowCardPopupEvent
    {
        /// <summary>
        /// The icon image to be displayed on the card popup.
        /// </summary>
        public readonly Sprite Icon { get; }
        /// <summary>
        /// The name or title to be shown on the card popup.
        /// </summary>
        public readonly string Name { get; }
        /// <summary>
        /// The count of rewards associated with the card.
        /// </summary>
        public readonly int RewardCount { get; }
        /// <summary>
        /// The identifier for the item represented by the card.
        /// </summary>
        public readonly string ItemId { get; }

        /// <summary>
        /// Initializes a new instance of the ShowCardPopupEvent struct with specified icon, name, reward count, and item ID.
        /// </summary>
        public ShowCardPopupEvent(Sprite icon, string name,int rewardCount,string itemId)
        {
            Icon = icon;
            Name = name;
            RewardCount = rewardCount;
            ItemId = itemId;
        }
    }
}