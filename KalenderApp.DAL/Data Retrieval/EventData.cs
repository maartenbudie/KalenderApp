using System.Data.SqlClient;
using KalenderApp.Core;

namespace KalenderApp.DAL
{
    public class EventData : IEventData
    {
        public List<EventDTO> getEventsForDay(DateTime dateTime)
        {
            List<EventDTO> events = new List<EventDTO>();

            dateTime = dateTime.Date;

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseClass.connectionString))
                {
                    string query = $"SELECT * FROM event WHERE CONVERT(date, start_time) = @dateTime";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dateTime", dateTime);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();                 
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        int category_id = Convert.ToInt32(reader["category_id"]);
                        string name = Convert.ToString(reader["name"]);
                        DateTime start_time = DateTime.Parse(Convert.ToString(reader["start_time"]));
                        DateTime end_time = DateTime.Parse(Convert.ToString(reader["end_time"]));
                        string location = Convert.ToString(reader["location"]);
                        Repetition repetition = (Repetition)Enum.Parse(typeof(string), Convert.ToString(reader["repetition"]), true);                        
                        EventDTO eventDTO = new EventDTO(id, category_id, name, start_time, end_time, location, repetition);
                        events.Add(eventDTO);
                    }
                    reader.Close();
                }
            }
            catch
            {
                Console.WriteLine("Error retrieving data");
            }
            return events;
        }
    }
}
