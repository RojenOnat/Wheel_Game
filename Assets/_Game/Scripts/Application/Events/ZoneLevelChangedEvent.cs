namespace _Game.Scripts.Application.Events
{
    /// <summary>
    /// Represents an event that indicates a change in the zone level.
    /// </summary>
    public readonly struct ZoneLevelChangedEvent
    {
        /// <summary>
        /// Gets the new level of the zone after the change.
        /// </summary>
        public int Level { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneLevelChangedEvent"/> struct with the specified level.
        /// </summary>
        /// <param name="level">The new level of the zone.</param>
        public ZoneLevelChangedEvent(int level) => Level = level;
    }
}