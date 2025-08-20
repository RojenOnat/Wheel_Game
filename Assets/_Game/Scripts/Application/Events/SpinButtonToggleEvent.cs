/// <summary>
/// Represents an event used to enable or disable the spin button.
/// </summary>
namespace _Game.Scripts.Application.Events
{
    public readonly struct SpinButtonToggleEvent
    {
        /// <summary>
        /// Indicates whether the spin button is active (enabled) or not.
        /// </summary>
        public readonly bool IsActive;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpinButtonToggleEvent"/> struct with the specified active state.
        /// </summary>
        /// <param name="isActive">If set to <c>true</c>, the spin button is enabled; otherwise, it is disabled.</param>
        public SpinButtonToggleEvent(bool isActive)
        {
            IsActive = isActive;
        }
    }
}