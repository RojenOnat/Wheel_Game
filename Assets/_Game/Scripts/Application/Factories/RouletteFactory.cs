using _Game.Scripts.Domain;
using _Game.Scripts.Infrastructure.Config;

namespace _Game.Scripts.Application.Factories
{
    /// <summary>
    /// Factory for creating RouletteData instances.
    /// </summary>
    public class RouletteFactory
    {
        /// <summary>
        /// Creates a new RouletteData instance from RouletteTypeData.
        /// </summary>
        public static RouletteData Create(RouletteTypeData data)
        {
            return new RouletteData(data.Id,data.DisplayName);
        }
    }
}
