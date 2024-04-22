using KalenderApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using KalenderApp.Core;
using KalenderApp.DAL;
using System.Text.Json.Nodes;

namespace KalenderApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult getAllEvents(int date, int month, int year){
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            DateTime dateTime = DateTime.Parse($"{date} {months[month]} {year}");
            Console.WriteLine(dateTime);

            IEventData eventData = new EventData();
            EventService eventService = new EventService();

            List<EventDTO> eventDTOs = eventService.getEventsForDay(eventData, dateTime);

            List<object> events = new List<object>();

            foreach(EventDTO eventDTO in eventDTOs){
                var _event = new {
                    id = eventDTO.id,
                    categoryId = eventDTO.categoryId,
                    name = eventDTO.name,
                    start_time = Convert.ToString(eventDTO.startTime),
                    end_time = Convert.ToString(eventDTO.endTime),
                    location = eventDTO.location,
                    repetition = Convert.ToString(eventDTO.repetition)
                };

                events.Add(_event);
            }
            return Json(new{events});
        }
        [HttpPost]
        public void addNewEvent(string name, string startTime, string endTime, string location, string repetition)
        {
            DateTime start = DateTime.Parse(startTime);
            DateTime end = DateTime.Parse(endTime);

            IEventData eventData = new EventData();
            EventService eventService = new EventService();

            eventService.addNewEvent(name, start, end, location, repetition, eventData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
