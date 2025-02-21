namespace SportTime.DAL.Entities
{
    public class Stadium
    {
        public long StadiumId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Price { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        public Dictionary<double, double>? Location { get; set; }

    }
}
