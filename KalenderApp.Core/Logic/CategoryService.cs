namespace KalenderApp.Core.Logic;

public class CategoryService
{
    ICategoryData categoryData;
    public CategoryService(ICategoryData categoryData)
    {
        this.categoryData = categoryData;
    }
    public List<CategoryEntity> GetAllCategories()
    {
        try
        {
            List<CategoryDTO> categories = categoryData.GetAllCategories();
            List<CategoryEntity> entities = new List<CategoryEntity>();

            foreach (CategoryDTO category in categories)
            {
                CategoryEntity categoryEntity = new CategoryEntity(category);
                entities.Add(categoryEntity);
            }
            return entities;
        }
        catch (DataException ex) { throw ex; }
    }
    public List<CategoryEntity> GetCategoriesForEvent(int id)
    {
        try
        {
            if (id < 0) throw new InvalidValueException("Invalid Event");

            List<CategoryDTO> categories = categoryData.GetCategoriesForEvent(id);
            List<CategoryEntity> entities = new List<CategoryEntity>();

            foreach (CategoryDTO category in categories)
            {
                CategoryEntity categoryEntity = new CategoryEntity(category);
                entities.Add(categoryEntity);
            }
            return entities;
        }
        catch (DataException ex) { throw ex; }
    }
    public void AddNewCategory(string name, string colour)
    {
        try
        {
            if(name == String.Empty) throw new InvalidValueException("Invalid Name: Name can't be empty.");
            if(colour.Length > 6) throw new InvalidValueException("Invalid colour code.");
            if(colour.Any(ch => ! char.IsLetterOrDigit(ch))) throw new InvalidValueException("Invalid colour code.");
            categoryData.AddNewCategory(name, colour);
        }
        catch (DataException ex) { throw ex; }
    }
}
