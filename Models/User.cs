namespace SKY_Journey.Models
{
    public class User  // Renamed class from Client to User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
