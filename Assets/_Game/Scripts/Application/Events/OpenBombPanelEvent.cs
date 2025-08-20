namespace _Game.Scripts.Application.Events
{
    /// <summary>
    /// Event used to signal the opening or closing of the bomb panel in the game UI.
    /// </summary>
    // Immutable event struct to notify UI about bomb panel state changes.
    public readonly struct OpenBombPanelEvent
    {
        /// <summary>
        /// Indicates if the bomb panel is open (true) or closed (false).
        /// </summary>
        // True if the bomb panel should be displayed, false otherwise.
        public readonly bool IsOpen;

        /// <summary>
        /// Initializes a new instance of the OpenBombPanelEvent with the specified open state.
        /// </summary>
        /// <param name="isOpen">True to open the bomb panel, false to close it.</param>
        public OpenBombPanelEvent(bool isOpen)
        {
            IsOpen = isOpen;
        }
    }
}