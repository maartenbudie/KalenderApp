namespace KalenderApp.Core;

public class EventService
{
    public EventService(){
    }

    public List<EventDTO> getEventsForDay(IEventData eventData, DateTime dateTime)
    {
        return eventData.getEventsForDay(dateTime);
    }
    public void addNewEvent(string name, DateTime start, DateTime end, string location, string repetition, IEventData eventData)
    {
        EventDTO eventDTO = new EventDTO(1 /*temporary*/, name, start, end, location, repetition);

        eventData.addNewEvent(eventDTO);
    }
}
