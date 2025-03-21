using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKY_Journey.Data;  // Corrected namespace for SkyJourneyDbContext
using SKY_Journey.Models;  // Corrected namespace for the User model
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SKY_Journey.Controllers
{
    public class LoginRegisterController : Controller
    {
        private readonly SkyJourneyDbContext _context;  // Updated to SkyJourneyDbContext

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

            // Hash the entered password to compare with the stored password hash
            string hashedPassword = HashPassword(password);

            // Check if the user exists in the Users table
            var user = _context.Users
                .Where(u => u.Email == email && u.PasswordHash == hashedPassword)
                .FirstOrDefault();

            if (user == null)
            {
                ViewBag.ErrorMessage = "User not found. Please register.";
                return View("~/Views/Login&Register/login.cshtml");
            }

            // Successful login logic (e.g., create session, cookie, etc.)
            return RedirectToAction("Index", "Home");
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte byteValue in bytes)
                {
                    builder.Append(byteValue.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
