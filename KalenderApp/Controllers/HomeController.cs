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
        public IActionResult GetAllEventsForDate(int date, int month, int year)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            DateTime dateTime = DateTime.Parse($"{date} {months[month]} {year}");
            Console.WriteLine(dateTime);

            IEventData eventData = new EventData();
            EventService eventService = new EventService(eventData);

            List<EventEntity> eventEntities = eventService.GetEventsForDay(dateTime);

            List<object> events = new List<object>();

            foreach (EventEntity eventEntity in eventEntities)
            {
                var _event = new
                {
                    id = eventEntity.id,
                    categoryId = eventEntity.categoryId,
                    name = eventEntity.name,
                    start_time = eventEntity.startTime.ToString("HH:mm"),
                    end_time = eventEntity.endTime.ToString("HH:mm"),
                    location = eventEntity.location,
                    repetition = Convert.ToString(eventEntity.repetition)
                };
                events.Add(_event);
            }
            return Json(new { events });
        }
        [HttpPost]
        public void AddNewEvent(string name, string startTime, string endTime, string location, string repetition)
        {
            try
            {
                DateTime start = DateTime.Parse(startTime);
                DateTime end = DateTime.Parse(endTime);

                IEventData eventData = new EventData();
                EventService eventService = new EventService(eventData);

                eventService.AddNewEvent(name, start, end, location, repetition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpPost]
        public void EditEvent(int id, string name, string startTime, string endTime, string location, string repetition)
        {
            try
            {
                DateTime start = DateTime.Parse(startTime);
                DateTime end = DateTime.Parse(endTime);

                IEventData eventData = new EventData();
                EventService eventService = new EventService(eventData);

                eventService.EditEvent(id, name, start, end, location, repetition);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpPost]
        public void DeleteEvent(int id)
        {
            try
            {
                IEventData eventData = new EventData();
                EventService eventService = new EventService(eventData);

                eventService.DeleteEvent(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult GetAllCategories()
        {
            ICategoryData categoryData = new CategoryData();
            CategoryService categoryService = new CategoryService(categoryData);
            List<CategoryDTO> categoryDTOs = categoryService.GetAllCategories();
            List<object> categories = new List<object>();

            try
            {

                foreach (CategoryDTO category in categoryDTOs)
                {
                    var _category = new
                    {
                        id = category.id,
                        name = category.name,
                        colour = category.colour
                    };
                    categories.Add(_category);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(new { categories });
        }

        [HttpPost]
        public void AddNewCategory(string name, string colour)
        {
            ICategoryData categoryData = new CategoryData();
            CategoryService categoryService = new CategoryService(categoryData);

            categoryService.AddNewCategory(name, colour);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
