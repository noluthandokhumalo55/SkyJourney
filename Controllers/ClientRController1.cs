using Microsoft.AspNetCore.Mvc;
using SKY_Journey.Models;
using Microsoft.Data.SqlClient;
using BCrypt.Net;

namespace SKY_Journey.Controllers
{
    public class ClientRController1 : Controller
    {
        private readonly string _connectionString = "Data Source=noluthando\\sqlexpress01;Initial Catalog=sky;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public IActionResult Index()
        {
            return View("~/Views/Login&Register/ClientR.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(ClientRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Ensure that both password fields match
                    if (model.Password != model.ConfirmPassword)
                    {
                        ModelState.AddModelError("", "Passwords do not match.");
                        return View("~/Views/Login&Register/ClientR.cshtml", model);
                    }

                    // Hash the password typed by the user before storing it in the database
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        string query = "INSERT INTO Clients (FullName, Email, PasswordHash) VALUES (@FullName, @Email, @PasswordHash)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Add parameters to prevent SQL injection
                            command.Parameters.AddWithValue("@FullName", model.FullName);
                            command.Parameters.AddWithValue("@Email", model.Email);
                            command.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                            connection.Open();
                            command.ExecuteNonQuery(); // Execute the query to insert data into the database
                        }
                    }

                    // If registration is successful, set a success message
                    TempData["SuccessMessage"] = "Registration successful!";
                    return RedirectToAction("Index"); // Redirect to the same page after successful registration
                }
                catch (SqlException sqlEx)
                {
                    // Log or handle the error (You might want to log the error to a file or database)
                    ModelState.AddModelError("", "An error occurred while saving to the database: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    // Catch any general errors
                    ModelState.AddModelError("", "An unexpected error occurred: " + ex.Message);
                }
            }

            // Return the form with the validation errors if the model is not valid or if there's an exception
            return View("~/Views/Login&Register/ClientR.cshtml", model);
        }
    }
}
