using Microsoft.AspNetCore.Mvc;

namespace SKY_Journey.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
