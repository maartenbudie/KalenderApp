namespace KalenderApp.DAL;

public class EventDTO
{
    public int id { get; private set; }
    public int organiserId { get; private set; }
    public string name { get; private set; }
    public DateTime startTime { get; private set; }
    public DateTime endTime { get; private set; }
    public string? location { get; private set; }
    public Repetition? repetition { get; private set; }

    public EventDTO(int id, int organiserId, string name, DateTime startTime, DateTime endTime, string? location, Repetition? repetition)
    {
        this.id = id;
        this.organiserId = organiserId;
        this.name = name;
        this.startTime = startTime;
        this.endTime = endTime;
        this.location = location;
        this.repetition = repetition;
    }
}
