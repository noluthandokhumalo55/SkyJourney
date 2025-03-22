using Microsoft.AspNetCore.Mvc;

namespace SKY_Journey.Controllers
{
    public class FlightsController : Controller
    {
        public IActionResult Index()
        {
            // Absolute path to the view
            return View("~/Views/Flights.cshtml");
        }
    }
}
