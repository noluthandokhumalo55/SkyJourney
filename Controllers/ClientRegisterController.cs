using Microsoft.AspNetCore.Mvc;
using SKY_Journey.Models;
using SKY_Journey.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace SKY_Journey.Controllers
{
    public class ClientRegisterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<Client> _passwordHasher;

        public ClientRegisterController(ApplicationDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<Client>();
        }

        public IActionResult Index()
        {
            return View("~/Views/Login&Register/clientregister.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Client client)
        {
            if (ModelState.IsValid)
            {
                // Check if passwords match
                if (client.PasswordHash != Request.Form["ConfirmPassword"])
                {
                    ModelState.AddModelError("ConfirmPassword", "Passwords do not match.");
                    return View("Index");
                }

                // Hash the password before storing it in the database
                client.PasswordHash = _passwordHasher.HashPassword(client, client.PasswordHash);

                // Save the client to the database
                _context.Add(client);
                await _context.SaveChangesAsync();

                // Redirect to login page or confirmation page
                return RedirectToAction("Index", "CustomerLogin");
            }

            return View("Index");
        }
    }
}
