using KalenderApp.Core;
using MySql.Data.MySqlClient;

namespace KalenderApp.DAL
{
    public class EventData : IEventData
    {
        public List<EventDTO> GetEventsForDay(DateTime dateTime)
        {
            List<EventDTO> events = new List<EventDTO>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DatabaseClass.connectionString))
                {
                    string query = "SELECT id, category_id, name, start_time, end_time, location, repetition FROM event WHERE DATE(start_time) = DATE(@dateTime)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dateTime", dateTime);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            int category_id = Convert.ToInt32(reader["category_id"]);
                            string name = Convert.ToString(reader["name"]);
                            DateTime start_time = DateTime.Parse(Convert.ToString(reader["start_time"]));
                            DateTime end_time = DateTime.Parse(Convert.ToString(reader["end_time"]));
                            string location = Convert.ToString(reader["location"]);
                            string repetition = Convert.ToString(reader["repetition"]);

                            EventDTO eventDTO = new EventDTO(id, category_id, name, start_time, end_time, location, repetition);
                            events.Add(eventDTO);
                        }
                    }
                }
                return events;
            }
            catch (MySqlException ex)
            {
                throw new Exception($"An error occurred. Please try again later or contact an administrator.\n\nError Code: {ex.Number}");
            }
        }

        public void AddNewEvent(EventDTO dto)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DatabaseClass.connectionString))
                {
                    string query = "INSERT INTO event (category_id, name, start_time, end_time, location, repetition) VALUES (@category_id, @name, @start_time, @end_time, @location, @repetition)";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.Parameters.AddWithValue("@category_id", dto.categoryId);
                    command.Parameters.AddWithValue("@name", dto.name);
                    command.Parameters.AddWithValue("@start_time", dto.startTime);
                    command.Parameters.AddWithValue("@end_time", dto.endTime);
                    command.Parameters.AddWithValue("@location", dto.location);
                    command.Parameters.AddWithValue("@repetition", dto.repetition);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("An error occurred. Please try again later." + ex.Number);
            }
        }
        public void EditEvent(EventDTO dto)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DatabaseClass.connectionString))
                {
                    string query = "UPDATE event SET category_id = @category_id, name = @name, start_time = @start_time, end_time = @end_time, location = @location, repetition = @repetition WHERE id = @id";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", dto.id);
                    command.Parameters.AddWithValue("@category_id", dto.categoryId);
                    command.Parameters.AddWithValue("@name", dto.name);
                    command.Parameters.AddWithValue("@start_time", dto.startTime);
                    command.Parameters.AddWithValue("@end_time", dto.endTime);
                    command.Parameters.AddWithValue("@location", dto.location);
                    command.Parameters.AddWithValue("@repetition", dto.repetition);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("An error occurred. Please try again later." + ex.Number);
            }
        }
        public void DeleteEvent(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DatabaseClass.connectionString))
                {
                    string query = "DELETE FROM event WHERE id = @id";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("An error occurred. Please try again later." + ex.Number);
            }
        }
    }
}
