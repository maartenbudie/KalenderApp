namespace KalenderApp.Core;

public class EventService
{
    public EventService(){
    }

    public List<EventDTO> getEventsForDay(IEventData eventData, DateTime dateTime)
    {
        return eventData.getEventsForDay(dateTime);
    }
}
