namespace KalenderApp.Core;

public class CategoryEntity
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? colour { get; set; }

    public CategoryEntity(CategoryDTO dto)
    {
        this.id = dto.id;
        this.name = dto.name;
        this.colour = dto.colour;
    }
}
