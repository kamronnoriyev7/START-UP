namespace SportTime.DAL.Entities
{
    public class Booking
    {
        public long BookingId { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
        public long StadiumId { get; set; }
        public Stadium? Stadium { get; set; }
        public double Payment { get; set; }


    }
}
