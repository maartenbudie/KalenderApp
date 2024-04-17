namespace KalenderApp.Core;

public class Event
{
    private int id;
    private int organiserId;
    private string? name;
    private DateTime startTime;
    private DateTime endTime;
    private string? location;
    private Repetition? repetition;

    public Event(EventDTO eventDTO){
        this.id = eventDTO.id;
        this.organiserId = eventDTO.organiserId;
        this.name = eventDTO.name;
        this.startTime = eventDTO.startTime;
        this.endTime = eventDTO.endTime;
        this.location = eventDTO.location;
        this.repetition = eventDTO.repetition;
    }
}
