namespace KalenderApp.Core;

public interface IEventData
{
    public List<EventDTO> GetEventsForDay(DateTime dateTime);
    public void AddNewEvent(EventDTO eventDTO);
    public void EditEvent(EventDTO eventDTO);
    public void DeleteEvent(int id);
}