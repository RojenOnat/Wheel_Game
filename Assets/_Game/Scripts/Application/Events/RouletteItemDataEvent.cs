using UnityEngine;

namespace _Game.Scripts.Application.Events
{
    public readonly struct RouletteItemDataEvent
    {
        public readonly string Id;        // Unique identifier for the slot or item
        public readonly int Count;        // Quantity of the item
        public readonly Sprite Icon;      // Visual representation of the item

        public RouletteItemDataEvent(string id, int count, Sprite icon)
        {
            Id = id;
            Count = count;
            Icon = icon;
        }
    }
}
