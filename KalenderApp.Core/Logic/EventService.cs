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
        catch(DataException ex){throw ex;}
    }
    public void AddNewEvent(List<int> categoryid, string name, DateTime start, DateTime end, string location, string repetition)
    {
        try
        {
            if(name == String.Empty) throw new InvalidValueException("Invalid Name: Name can't be empty.");
            if(start < DateTime.Now) throw new InvalidValueException("Invalid Date: Cannot add Event on passed date");
            if(repetition != "None" && repetition != "Daily" && repetition != "Weekly" && repetition != "Monthly" && repetition != "Quarterly" && repetition != "Annually") throw new InvalidValueException("Invalid Repetition.");
            EventDTO eventDTO = new EventDTO(categoryid, name, start, end, location, repetition);
            eventData.AddNewEvent(eventDTO);
        }
        catch(DataException ex){throw ex;}
    }
    public void EditEvent(int id, List<int> categoryid, string name, DateTime start, DateTime end, string location, string repetition)
    {
        try
        {
            if(id < 1) throw new InvalidValueException("Invalid Event");
            if(name == String.Empty) throw new InvalidValueException("Invalid Name: Name can't be empty.");
            if(start < DateTime.Now) throw new InvalidValueException("Invalid Date: Cannot add Event on passed date");
            if(repetition != "Daily" && repetition != "Weekly" && repetition != "Monthly" && repetition != "Quarterly" && repetition != "Yearly") throw new InvalidValueException("Invalid Repetition.");
            EventDTO eventDTO = new EventDTO(categoryid, name, start, end, location, repetition);
            eventData.EditEvent(eventDTO);
        }
        catch(DataException ex){throw ex;}
    }
    public void DeleteEvent(int id)
    {
        try
        {
            if(id < 1) throw new InvalidValueException("Invalid Event");
            eventData.DeleteEvent(id);
        }
        catch(DataException ex){throw ex;}
    }
}
