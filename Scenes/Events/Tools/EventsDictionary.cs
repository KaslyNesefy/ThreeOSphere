using System.Collections.Generic;

public enum EventsIndexes
{
    Initial
}

public class EventsDictionary
{
    public Dictionary<EventsIndexes, string> Paths = new Dictionary<EventsIndexes, string>
    {
        [EventsIndexes.Initial] = ""
    };
}

