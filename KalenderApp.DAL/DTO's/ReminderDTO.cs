namespace KalenderApp.DAL.DTO;

public class ReminderDTO
{
    public int id { get; set; }
    public string name { get; set; }
    public DateTime time { get; set; }
    public Repetition repetition { get; set; }

    public ReminderDTO(int id, string name, DateTime time, Repetition repetition)
    {
        this.id = id;
        this.name = name;
        this.time = time;
        this.repetition = repetition;
    }
}
