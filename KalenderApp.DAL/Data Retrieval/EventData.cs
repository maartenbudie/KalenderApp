using KalenderApp.Core;
using MySql.Data.MySqlClient;

namespace KalenderApp.DAL
{
    public class EventData : IEventData
    {
        public List<EventDTO> getEventsForDay(DateTime dateTime)
        {
            List<EventDTO> events = new List<EventDTO>();
            Console.WriteLine(dateTime.Date);

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DatabaseClass.connectionString))
                {
                    string query = $"SELECT * FROM event WHERE DATE(start_time) = DATE(@dateTime)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dateTime", dateTime);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
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
                    reader.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return events;
        }
    }
}
