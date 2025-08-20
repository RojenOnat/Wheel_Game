namespace _Game.Scripts.Domain
{
    /// <summary>
    /// Represents an item on the roulette wheel.
    /// </summary>
    public sealed class WheelItem
    {
        /// <summary>
        /// Gets the unique identifier of the wheel item.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the name of the wheel item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the reward value associated with the wheel item.
        /// </summary>
        public int Reward { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WheelItem"/> class with the specified id, name, and reward.
        /// </summary>
        /// <param name="id">The unique identifier of the wheel item.</param>
        /// <param name="name">The name of the wheel item.</param>
        /// <param name="reward">The reward value of the wheel item.</param>
        public WheelItem(string id, string name, int reward)
        {
            Id = id;
            Name = name;
            Reward = reward;
        }
    }
}
