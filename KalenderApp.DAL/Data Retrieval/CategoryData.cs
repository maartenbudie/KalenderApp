using KalenderApp.Core;
using MySql.Data.MySqlClient;

namespace KalenderApp.DAL;

public class CategoryData : ICategoryData
{
    public List<CategoryDTO> GetAllCategories()
    {
        List<CategoryDTO> categories = new List<CategoryDTO>();

        try
        {
            using(MySqlConnection connection = new MySqlConnection(DatabaseClass.connectionString))
            {
                string query = "SELECT * FROM category";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    int userId = 1; // temp
                    string name = Convert.ToString(reader["name"]);
                    string colour = Convert.ToString(reader["colour"]);

                    CategoryDTO category = new CategoryDTO(id, name, colour);
                    categories.Add(category);
                }
                reader.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return categories;
    }
}
