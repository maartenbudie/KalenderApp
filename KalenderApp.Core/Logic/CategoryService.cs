namespace KalenderApp.Core.Logic;

public class CategoryService
{
    ICategoryData categoryData;
    public CategoryService(ICategoryData categoryData)
    {
        this.categoryData = categoryData;
    }
    public List<CategoryDTO> GetAllCategories()
    {
        return categoryData.GetAllCategories();
    }
}
