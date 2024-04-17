using System.Data.SqlClient;
using KalenderApp.Core;

namespace KalenderApp.DAL
{
    public class EventData : IEventData
    {
        public List<EventDTO> getAllEvents()
        {
            List<EventDTO> events = new List<EventDTO>();

            try
            {
                // using (SqlConnection connection = new SqlConnection(DatabaseClass.connectionString))
                // {
                //     string query = "SELECT * FROM event";
                //     SqlCommand command = new SqlCommand(query, connection);
                //     connection.Open();
                //     SqlDataReader reader = command.ExecuteReader();

                //     while (reader.Read())
                //     {
                //         // int id = Convert.ToInt32(reader["id"]);
                //         // int category_id = Convert.ToInt32(reader["category_id"]);
                //         // string name = Convert.ToString(reader["name"]);
                //         // DateTime start_time = DateTime.Parse(Convert.ToString(reader["start_time"]));
                //         // DateTime end_time = DateTime.Parse(Convert.ToString(reader["end_time"]));
                //         // string location = Convert.ToString(reader["location"]);
                //         // Repetition repetition = (Repetition)Enum.Parse(typeof(string), Convert.ToString(reader["repetition"]), true);

                //         // EventDTO eventDTO = new EventDTO(id, category_id, name, start_time, end_time, location, repetition);
                //         // events.Add(eventDTO);
                //     }
                //     reader.Close();
                // }
            }
            catch
            {
                Console.WriteLine("Error retrieving data");
            }

            int id = 1;//Convert.ToInt32(reader["id"]);
            int category_id = 1;//Convert.ToInt32(reader["category_id"]);
            string name = "test";//Convert.ToString(reader["name"]);
            DateTime start_time = DateTime.Now;//DateTime.Parse(Convert.ToString(reader["start_time"]));
            DateTime end_time = DateTime.Now;//DateTime.Parse(Convert.ToString(reader["end_time"]));
            string location = "here";//Convert.ToString(reader["location"]);
            Repetition repetition = Repetition.None;//(Repetition)Enum.Parse(typeof(string), Convert.ToString(reader["repetition"]), true);

            EventDTO eventDTO = new EventDTO(id, category_id, name, start_time, end_time, location, repetition);
            events.Add(eventDTO);
            return events;
        }
    }
}
