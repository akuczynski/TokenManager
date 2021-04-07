namespace TokenManager.Core.Events
{
    public class ModelHasChangedEvent : IEvent  { }
    public class ProjectLoadedEvent : IEvent { }
    public class ProjectSavedEvent : IEvent { }

    public class SelectTokenEvent : IEvent
    {
        public string Token { get; set; }
    }

}
