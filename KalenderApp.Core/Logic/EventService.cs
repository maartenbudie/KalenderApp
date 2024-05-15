namespace KalenderApp.Core;

public class EventService
{
    IEventData eventData;
    public EventService(IEventData eventData){
        this.eventData = eventData;
    }

    public List<EventEntity> GetEventsForDay(DateTime dateTime)
    {
        List<EventDTO> events = eventData.GetEventsForDay(dateTime);
        List<EventEntity> eventEntities = new List<EventEntity>();

        foreach(EventDTO eventDTO in events)
        {
            EventEntity entity = new EventEntity(eventDTO);    
            eventEntities.Add(entity);
        }
        return eventEntities;
    }
    public void AddNewEvent(string name, DateTime start, DateTime end, string location, string repetition)
    {
        EventDTO eventDTO = new EventDTO(1 /*temporary*/, name, start, end, location, repetition);

        eventData.AddNewEvent(eventDTO);
    }
    public void EditEvent(int id, string name, DateTime start, DateTime end, string location, string repetition)
    {
        EventDTO eventDTO = new EventDTO(id, 1 /*temporary*/, name, start, end, location, repetition);

        eventData.EditEvent(eventDTO);
    }
    public void DeleteEvent(int id)
    {
        eventData.DeleteEvent(id);
    }
}
