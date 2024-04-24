namespace KalenderApp.Core;

public class EventService
{
    IEventData eventData;
    public EventService(IEventData eventData){
        this.eventData = eventData;
    }

    public List<EventDTO> GetEventsForDay(DateTime dateTime)
    {
        return eventData.GetEventsForDay(dateTime);
    }
    public void AddNewEvent(int categoryid, string name, DateTime start, DateTime end, string location, string repetition)
    {
        EventDTO eventDTO = new EventDTO(categoryid, name, start, end, location, repetition);

        eventData.AddNewEvent(eventDTO);
    }
    public void EditEvent(int id, int categoryid, string name, DateTime start, DateTime end, string location, string repetition)
    {
        EventDTO eventDTO = new EventDTO(id, categoryid, name, start, end, location, repetition);

        eventData.EditEvent(eventDTO);
    }
    public void DeleteEvent(int id)
    {
        eventData.DeleteEvent(id);
    }
}
