public class Event_Initialize : Event
{
    public Event_Initialize(EventPattern eventPattern) : base(eventPattern)
    {
    }

    public override void PreEnter()
    {
        base.PreEnter();
        _eventInfo.XmlFolderPath = "";
        _eventInfo.XmlFileName = nameof(Event_Initialize);
        _nextEvents.Add(new Event1(_eventPattern));
        _nextEvents.Add(new Event1(_eventPattern));
        _nextEvents.Add(new Event1(_eventPattern));
    }
}