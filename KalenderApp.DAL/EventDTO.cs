namespace KalenderApp.DAL
{
    public abstract class EventDTO
    {
        public int id;
        public int organiserId;
        private string name;
        private DateTime startTime;
        private DateTime endTime;
        private string location;
        private Repetition repetition;
    }
}