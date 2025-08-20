namespace _Game.Scripts.Domain
{
    /// <summary>
    /// Represents the data for a roulette, including its unique identifier and name.
    /// </summary>
    public sealed class RouletteData 
    {
        /// <summary>
        /// Stores the unique ID of the roulette.
        /// </summary>
        public int RouletteId;
        
        /// <summary>
        /// Stores the name of the roulette.
        /// </summary>
        public string RouletteName { get; }

        /// <summary>
        /// Initializes the roulette data with ID and name.
        /// </summary>
        public RouletteData(int rouletteId, string rouletteName)
        {
            RouletteId = rouletteId;
            RouletteName = rouletteName;
        }
    }
}
