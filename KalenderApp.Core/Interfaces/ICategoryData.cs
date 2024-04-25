namespace KalenderApp.Core;

public interface ICategoryData
{
    public List<CategoryDTO> GetAllCategories();
    public void AddNewCategory(string name, string colour);
}
