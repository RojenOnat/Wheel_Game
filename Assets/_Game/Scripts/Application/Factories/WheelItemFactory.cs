// Application/WheelItemFactory.cs

using _Game.Scripts.Domain;
using _Game.Scripts.Infrastructure.Config;

namespace _Game.Scripts.Application.Factories
{
    // Factory class responsible for creating WheelItem instances from data objects
    public static class WheelItemFactory
    {
        // Creates a new WheelItem based on the provided WheelItemData
        public static WheelItem Create(WheelItemData data)
        {
            return new WheelItem(data.Id, data.Name, data.Reward);
        }
    }
}