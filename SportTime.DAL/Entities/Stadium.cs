using SportTime.DAL.Configuration;

namespace SportTime.DAL.Entities
{
    public class Stadium
    {
        public long StadiumId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Price { get; set; }
        public string? PhoneNumber { get; set; }
        public long AdminId { get; set; }
        public Admin? Admin { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        public GeoLocation? Location { get; set; } // Dictionary o‘rniga GeoLocation ishlatamiz

    }
}
