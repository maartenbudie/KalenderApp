using System.Data.SqlClient;

namespace KalenderApp.DAL
{
    public class EventData
    {
        private int id;
        private int organiserId;
        private string name;
        private DateTime startTime;
        private DateTime endTime;
        private string? location;
        private Repetition? repetition;
        
        public List<int> getAllEventIDs()
        {
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

            }
            return eventIDs;
        }
    }
}
