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
}
