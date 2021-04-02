using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using TokenManager.Core.Events;

namespace TokenManager.Core.DomainServices
{
    public interface INotyficationService
    {
        void Subscribe(Type eventType, IEventHandler handler);

        void Publish(IEvent appEvent);
    }

    [Export(typeof(INotyficationService))]
    internal class NotyficationService : INotyficationService
    {
        private Dictionary<Type, IList<IEventHandler>> _eventHandlers { get; set; }

        public NotyficationService()
        {
            _eventHandlers = new Dictionary<Type, IList<IEventHandler>>();
        }

        public void Publish(IEvent appEvent)
        {
            var eventType = appEvent.GetType();
            if (_eventHandlers.ContainsKey(appEvent.GetType()))
            {
                var handlers = _eventHandlers[eventType];
                foreach (var handler in handlers)
                {
                    handler.Handle(appEvent);
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
