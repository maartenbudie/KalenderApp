namespace KalenderApp.Core;

public class EventDTO
{
    public int? id { get; private set; }
    public int[]? categoryId { get; private set; }
    public string name { get; private set; }
    public DateTime startTime { get; private set; }
    public DateTime endTime { get; private set; }
    public string? location { get; private set; }
    public string? repetition { get; private set; }

    public EventDTO(int id, int[] categoryId, string name, DateTime startTime, DateTime endTime, string? location, string? repetition)
    {
        this.id = id;
        this.categoryId = categoryId;
        this.name = name;
        this.startTime = startTime;
        this.endTime = endTime;
        this.location = location;
        this.repetition = repetition;
    }
    public EventDTO(int[] categoryId, string name, DateTime startTime, DateTime endTime, string? location, string? repetition){
        this.categoryId = categoryId;
        this.name= name;
        this.startTime = startTime;
        this.endTime= endTime;
        this.location = location;
        this.repetition= repetition;
    }
}
