namespace SportTime.DAL.Entities;

public class Admin
{
    public long AdminId { get; set; }
    public string? Name { get; set; }
    public string? Number { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public ICollection<Stadium>? Stadiums { get; set; }
    public ICollection<Booking>? Bookings { get; set; }
}
