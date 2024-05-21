namespace KalenderApp.Core;

public class EventService
{
    IEventData eventData;
    public EventService(IEventData eventData){
        this.eventData = eventData;
    }

    public List<EventEntity> GetEventsForDay(DateTime dateTime)
    {
        try
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
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
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
