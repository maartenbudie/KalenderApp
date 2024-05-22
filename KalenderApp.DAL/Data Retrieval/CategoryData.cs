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
            using (MySqlConnection connection = new MySqlConnection(DatabaseClass.connectionString))
            {
                string query = "SELECT * FROM category";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        int userId = 1; // temp
                        string name = Convert.ToString(reader["name"]);
                        string colour = Convert.ToString(reader["colour"]);

                        CategoryDTO category = new CategoryDTO(id, name, colour);
                        categories.Add(category);
                    }
                }
            }
        }
        catch (MySqlException ex)
        {
            throw new DataException($"An error occurred. Please try again later or contact an administrator.\n\nError Code: {ex.Number}");
        }
        return categories;
    }
    public void AddNewCategory(string name, string colour)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseClass.connectionString))
            {
                string query = "INSERT INTO category (user_id, name, colour) VALUES (@user_id, @name, @colour)";

                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@user_id", 1);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@colour", colour);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            throw new DataException($"An error occurred. Please try again later or contact an administrator.\n\nError Code: {ex.Number}");
        }
    }
    public List<CategoryDTO> GetCategoriesForEvent(int event_id)
    {
        List<CategoryDTO> categories = new List<CategoryDTO>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseClass.connectionString))
            {
                string query = "SELECT c.id, c.name, c.colour FROM category c JOIN event_category ec ON c.id = ec.category_id WHERE ec.event_id = @event_id;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@event_id", event_id);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        int userId = 1; // temp
                        string name = Convert.ToString(reader["name"]);
                        string colour = Convert.ToString(reader["colour"]);

                        CategoryDTO category = new CategoryDTO(id, name, colour);
                        categories.Add(category);
                    }
                }
            }
        }
        catch (MySqlException ex)
        {
            throw new DataException(ex.Message);
        }
        return categories;
    }
}
