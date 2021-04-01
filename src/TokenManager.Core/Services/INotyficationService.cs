using System;
using TokenManager.Core.Events;

namespace TokenManager.Core.Services
{
    public interface INotyficationService
    {
        void Subscribe(Type eventType, IEventHandler handler);

        void Publish(IEvent @event);
    }
}
