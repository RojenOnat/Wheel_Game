// This event struct is used to signal that the roulette wheel spin has stopped,
// carrying information about the result value of the spin.
namespace _Game.Scripts.Application.Events
{
  public readonly struct RouletteSpinStoppedEvent
  {
    // Represents the result value of the roulette spin.
    public readonly int RouletteSpinValue { get; }

    // Constructor to initialize the event with the spin result value.
    public RouletteSpinStoppedEvent(int spinValue) => RouletteSpinValue = spinValue;
  }
}
