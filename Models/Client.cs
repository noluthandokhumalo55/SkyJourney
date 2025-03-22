using System.ComponentModel.DataAnnotations;

namespace SKY_Journey.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        // Store the hashed password in PasswordHash, not Password
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; } = string.Empty;  // Use only PasswordHash for querying
    }
}
