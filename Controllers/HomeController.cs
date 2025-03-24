using Microsoft.AspNetCore.Mvc;
using SKY_Journey.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;  // For session handling

namespace SKY_Journey.Controllers
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
            // Check if the user is logged in (using session)
            if (HttpContext.Session.GetString("UserLoggedIn") == null)
            {
                return RedirectToAction("Login", "LoginRegister");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
