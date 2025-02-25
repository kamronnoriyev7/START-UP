using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportTime.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SportTime.DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(builder => builder.UserId);
            builder.Property(u => u.UserId).ValueGeneratedOnAdd();
            builder.Property(u => u.Name).IsRequired().HasMaxLength(30);
            builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(9);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(30);
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.HasMany(u => u.Bookings).WithOne(b => b.User).HasForeignKey(b => b.UserId);
            builder.HasMany(b => b.Payments).WithOne(b => b.User).HasForeignKey(b => b.UserId);
            builder.Property(u => u.Location)
               .HasConversion(
                   v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null), // JSON formatga o‘girish
                   v => JsonSerializer.Deserialize<GeoLocation>(v, (JsonSerializerOptions?)null) // JSON dan obyektga o‘girish
               )
               .HasColumnType("nvarchar(max)"); // Ma’lumotlar bazasida JSON sifatida saqlanadi

        }
    }
}
