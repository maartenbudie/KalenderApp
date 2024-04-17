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

        public List<EventLogic> getAllEvents(){
            IEventData eventData = new EventData();

            List<EventDTO> eventDTOs = eventData.getAllEvents();
            List<EventLogic> events = new List<EventLogic>();

            foreach(EventDTO eventDTO in eventDTOs){
                EventLogic eventLogic = new EventLogic(eventDTO);
                events.Add(eventLogic);
            }

            return events;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
