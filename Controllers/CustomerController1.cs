using Microsoft.AspNetCore.Mvc;

namespace SKY_Journey.Controllers
{
    public class CustomerController1 : Controller
    {
        // Action to show the customer registration form
        public IActionResult CustomerRegister()
        {
            // Explicitly return the view from Login&Register folder
            return View("~/Views/Login&Register/custmerregister.cshtml");
        }
    }
}
