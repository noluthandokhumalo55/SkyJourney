using Microsoft.AspNetCore.Mvc;

namespace SKY_Journey.Controllers
{
    public class LoginRegisterController : Controller
    {
        // Show the Login View
        public IActionResult Login()
        {
            return View("~/Views/Login&Register/login.cshtml"); // Explicitly set the path
        }
    }
}
