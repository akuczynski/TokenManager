namespace TokenManager.Core.Events
{
    public interface IEventHandler
    {
        void Handle(IEvent @event);
    }
}
