using System.Data.SqlClient;
using KalenderApp.Core;

namespace KalenderApp.DAL
{
    public class EventData : IEventData
    {
        public List<int> getAllEventIDs()
        {
            int id;
            List<int> eventIDs = new List<int>();

            try{
                using(SqlConnection connection = new SqlConnection(DatabaseClass.connectionString))
                {
                    string query = "SELECT id FROM event";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()){
                        id = Convert.ToInt32(reader["ID"]);
                        eventIDs.Add(id);
                    }
                    reader.Close();
                }
            }
            catch{
                Console.WriteLine("Error retrieving data");
            }
            return eventIDs;
        }
    }
}
