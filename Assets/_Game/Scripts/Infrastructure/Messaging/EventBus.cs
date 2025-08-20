using System;
using System.Collections.Generic;

namespace _Game.Scripts.Infrastructure.Messaging
{
    /// <summary>
    /// A simple event bus that allows subscribing to, unsubscribing from, and publishing events of different types.
    /// </summary>
    public class EventBus
    {
        // Dictionary to hold event type keys and their corresponding delegates (handlers).
        private readonly Dictionary<Type, Delegate> _subscribers = new();

        /// <summary>
        /// Subscribes a handler to an event of type T.
        /// </summary>
        /// <typeparam name="T">The event type to subscribe to.</typeparam>
        /// <param name="handler">The handler to invoke when the event is published.</param>
        public void Subscribe<T>(Action<T> handler)
        {
            // If there are no subscribers for this event type yet, initialize with null.
            if (!_subscribers.ContainsKey(typeof(T)))
                _subscribers[typeof(T)] = null;

            // Add the handler to the invocation list for this event type.
            _subscribers[typeof(T)] = (Action<T>)_subscribers[typeof(T)] + handler;
        }

        /// <summary>
        /// Unsubscribes a handler from an event of type T.
        /// </summary>
        /// <typeparam name="T">The event type to unsubscribe from.</typeparam>
        /// <param name="handler">The handler to remove.</param>
        public void Unsubscribe<T>(Action<T> handler)
        {
            // If there are subscribers for this event type, remove the handler from the invocation list.
            if (_subscribers.ContainsKey(typeof(T)))
                _subscribers[typeof(T)] = (Action<T>)_subscribers[typeof(T)] - handler;
        }

        /// <summary>
        /// Publishes an event of type T to all subscribed handlers.
        /// </summary>
        /// <typeparam name="T">The event type to publish.</typeparam>
        /// <param name="evt">The event data to pass to handlers.</param>
        public void Publish<T>(T evt)
        {
            // If there are subscribers for this event type, invoke all handlers with the event data.
            if (_subscribers.TryGetValue(typeof(T), out var d))
                (d as Action<T>)?.Invoke(evt);
        }
    }
}