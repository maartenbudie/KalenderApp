namespace KalenderApp.DAL;
public class CategoryDTO
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? colour { get; set; }

    public CategoryDTO(int id, string name, string colour)
    {
        this.id = id;
        this.name = name;
        this.colour = colour;
    }
}

