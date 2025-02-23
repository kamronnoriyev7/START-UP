using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportTime.DAL.Entities;
using System.Text.Json;

namespace SportTime.DAL.Configuration
{
    public class StadiumConfiguration : IEntityTypeConfiguration<Stadium>
    {
        public void Configure(EntityTypeBuilder<Stadium> builder)
        {
            builder.ToTable("stadiums");
            builder.HasKey(builder => builder.StadiumId);
            builder.Property(s => s.StadiumId).ValueGeneratedOnAdd();
            builder.Property(s => s.Name).IsRequired().HasMaxLength(30);
            builder.Property(s => s.PhoneNumber).IsRequired().HasMaxLength(9);
            builder.Property(s => s.Address).IsRequired();
            builder.Property(s => s.Price).IsRequired();
            builder.HasMany(s => s.Bookings).WithOne(b => b.Stadium).HasForeignKey(b => b.StadiumId);
            builder.Property(s => s.Location)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null), // JSONga o‘girish
                v => JsonSerializer.Deserialize<GeoLocation>(v, (JsonSerializerOptions?)null) // JSONni obyektga aylantirish
                )
            .HasColumnType("nvarchar(max)"); // Ma’lumotlar bazasida JSON sifatida saqlanadi

        }
    }
}
