﻿using SportTime.DAL.Enums;

namespace SportTime.DAL.Entities
{
    public class Payment
    {
        public long PaymentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public double Price { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
        public long BookingId { get; set; }
        public Booking? Booking { get; set; }
    }
}
