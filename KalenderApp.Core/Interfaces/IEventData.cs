namespace KalenderApp.Core;

public interface IEventData
{
    public List<EventDTO> getEventsForDay(DateTime dateTime);
    public void addNewEvent(EventDTO eventDTO);
}