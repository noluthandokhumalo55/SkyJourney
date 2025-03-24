// Models/FlightSearch.cs
namespace SkyJourney.Models
{
    public class FlightSearch
    {
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string FlightType { get; set; }
        public DateTime? DepartingDate { get; set; }
        public DateTime? ReturningDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
    }
}
