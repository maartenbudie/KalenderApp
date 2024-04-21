namespace KalenderApp.Core;

public class EventService
{
    private int id;
    private int organiserId;
    private string? name;
    private DateTime startTime;
    private DateTime endTime;
    private string? location;
    private Repetition? repetition;

    public EventService(){
    }

    public List<EventDTO> getEventsForDay(IEventData eventData, DateTime dateTime)
    {
        return eventData.getEventsForDay(dateTime);
    }
}
