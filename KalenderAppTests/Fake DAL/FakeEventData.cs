using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalenderApp.Core;

namespace KalenderAppTests.Fake_DAL
{
    internal class FakeEventData : IEventData
    {
        public bool addReached = false;
        public bool deleteReached = false;
        public bool editReached = false;
        public FakeEventData() 
        {
            
        }

        public void AddNewEvent(EventDTO eventDTO)
        {
            addReached = true;
        }

        public void DeleteEvent(int id)
        {
            deleteReached = true;
        }

        public void EditEvent(EventDTO eventDTO)
        {
            editReached = true;
        }

        public List<EventDTO> GetEventsForDay(DateTime dateTime)
        {
            return [new EventDTO([1], " ", dateTime, DateTime.Now, " ", "Daily")];
        }
    }
}
