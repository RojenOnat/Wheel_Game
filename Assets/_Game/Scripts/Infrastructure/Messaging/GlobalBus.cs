namespace _Game.Scripts.Infrastructure.Messaging
{
    /// <summary>
    /// Provides a globally accessible event bus instance for application-wide messaging.
    /// </summary>
    public static class GlobalBus
    {
        // The globally accessible event bus instance.
        public static EventBus Instance { get; } = new EventBus();
    }
}