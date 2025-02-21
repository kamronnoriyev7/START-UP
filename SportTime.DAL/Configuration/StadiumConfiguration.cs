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
        }
    }
}
