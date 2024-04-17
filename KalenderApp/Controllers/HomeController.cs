using KalenderApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using KalenderApp.Core;
using KalenderApp.DAL;

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
        public IActionResult getAllEvents(){
            IEventData eventData = new EventData();
            List<EventDTO> eventDTOs = eventData.getAllEvents();

            List<object> events = new List<object>();

            foreach(EventDTO eventDTO in eventDTOs){
                var _event = new {
                    id = eventDTO.id,
                    organiserId = eventDTO.organiserId,
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
