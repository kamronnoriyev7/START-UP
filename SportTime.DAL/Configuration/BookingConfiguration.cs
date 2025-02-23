using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportTime.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTime.DAL.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("bookings");
            builder.HasKey(builder => builder.BookingId);
            builder.Property(b => b.BookingId).ValueGeneratedOnAdd();
            builder.Property(b => b.DateTime).ValueGeneratedOnAdd();
            builder.HasOne(b => b.User).WithMany(u => u.Bookings).HasForeignKey(b => b.UserId);
            builder.HasOne(b => b.Stadium).WithMany(s => s.Bookings).HasForeignKey(b => b.StadiumId);
        }
    }
}
