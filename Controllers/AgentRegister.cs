using Microsoft.AspNetCore.Mvc;

namespace SKY_Journey.Controllers
{
    public class AgentRegisterController : Controller
    {
        // GET: AgentRegister
        public IActionResult Index()
        {
            // Return the agentregister.cshtml view from Views/Login&Register
            return View("~/Views/Login&Register/agentregister.cshtml");
        }

        // POST: AgentRegister
        [HttpPost]
        public IActionResult Register(string Email, string Username, string Password, string ConfirmPassword, string AgencyName, string LicenseNumber)
        {
            if (Password != ConfirmPassword)
            {
                // Add an error to the ModelState if passwords do not match
                ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return View("~/Views/Login&Register/agentregister.cshtml"); // Return to the registration page (agentregister.cshtml)
            }

            // Add logic to save the registration details to the database
            // Example: Save to database using a service or context

            // After successful registration, redirect to a confirmation page or dashboard
            return RedirectToAction("RegistrationSuccess");
        }

        // A success page that can be used to confirm registration
        public IActionResult RegistrationSuccess()
        {
            return View(); // This could return a simple success message or a different view
        }
    }
}
