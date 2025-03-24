using Microsoft.AspNetCore.Mvc;
using SKY_Journey.Data;  // Corrected namespace for SkyJourneyDbContext
using SKY_Journey.Models;  // Corrected namespace for the Client model
using BCrypt.Net;  // Add this for BCrypt password comparison

namespace SKY_Journey.Controllers
{
    public class LoginRegisterController : Controller
    {
        private readonly SkyJourneyDbContext _context;

        public LoginRegisterController(SkyJourneyDbContext context)
        {
            _context = context;
        }

        // Show the Login View
        public IActionResult Login()
        {
            return View("~/Views/Login&Register/login.cshtml");
        }

        // Handle Login Post Request
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Email and password cannot be empty!";
                return View("~/Views/Login&Register/login.cshtml");
            }

            // Check if the user exists in the Clients table
            var user = _context.Clients
                .Where(u => u.Email == email)
                .FirstOrDefault();

            if (user == null)
            {
                ViewBag.ErrorMessage = "User not found. Please register.";
                return View("~/Views/Login&Register/login.cshtml");
            }

            // Verify the hashed password using BCrypt
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                ViewBag.ErrorMessage = "Incorrect password. Please try again.";
                return View("~/Views/Login&Register/login.cshtml");
            }

            // Successful login logic (e.g., create session)
            // Set session to indicate the user is logged in
            HttpContext.Session.SetString("UserLoggedIn", user.Email);

            // Redirect to the home page after login
            return RedirectToAction("Index", "Home");
        }
    }
}
