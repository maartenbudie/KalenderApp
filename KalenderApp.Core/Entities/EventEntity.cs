namespace KalenderApp.Core;

public class EventEntity
{
    public int? id { get; private set; }
    public List<int> categoryId { get; private set; }
    public string name { get; private set; }
    public DateTime startTime { get; private set; }
    public DateTime endTime { get; private set; }
    public string? location { get; private set; }
    public string? repetition { get; private set; }

    public EventEntity(EventDTO eventDTO)
    {
        this.id = eventDTO.id;
        this.categoryId = eventDTO.categoryId;
        this.name = eventDTO.name;
        this.startTime = eventDTO.startTime;
        this.endTime = eventDTO.endTime;
        this.location = eventDTO.location;
        this.repetition = eventDTO.repetition;
    }
}
