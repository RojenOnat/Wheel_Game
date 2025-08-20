namespace _Game.Scripts.Application.Events
{
    /// <summary>
    /// Event to request adding one or more zone numbers.
    /// </summary>
    public readonly struct AddZoneNumberEvent
    {
        /// <summary>
        /// The number of zones to spawn (default is 1).
        /// </summary>
        public readonly int Count; 

        /// <summary>
        /// Initializes the event with the specified count.
        /// </summary>
        /// <param name="count">Number of zones to add (default is 1).</param>
        public AddZoneNumberEvent(int count = 1)
        {
            Count = count;
        }
    }
}