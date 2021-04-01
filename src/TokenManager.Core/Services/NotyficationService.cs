using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using TokenManager.Core.Events;

namespace TokenManager.Core.Services
{
    [Export(typeof(INotyficationService))]
    internal class NotyficationService : INotyficationService
    {
        private Dictionary<Type, IList<IEventHandler>> _eventHandlers { get; set; }

        public NotyficationService()
        {
            _eventHandlers = new Dictionary<Type, IList<IEventHandler>>();
        }

        public void Publish(IEvent @event)
        {
            var eventType = @event.GetType();
            if (_eventHandlers.ContainsKey(@event.GetType()))
            {
                var handlers = _eventHandlers[eventType];
                foreach (var handler in handlers)
                {
                    handler.Handle(@event);
                }
            }
        }

        public void Subscribe(Type eventType, IEventHandler handler)
        {
            if (!_eventHandlers.ContainsKey(eventType))
            {
                _eventHandlers.Add(eventType, new List<IEventHandler>());
            }

            if (_eventHandlers[eventType].Contains(handler))
            {
                return;
            }

            _eventHandlers[eventType].Add(handler);
        }
    }
}
