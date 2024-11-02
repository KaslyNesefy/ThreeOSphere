public class Event1 : Event
{
    
    public Event1(EventPattern eventPattern) : base(eventPattern)
    {
    }
    public override void PreEnter()
    {
        base.PreEnter();
        _eventInfo.XmlFolderPath = "";
        _eventInfo.XmlFileName = nameof(Event1);
        _nextEvents.Add(new Event_Initialize(_eventPattern));
    }

}