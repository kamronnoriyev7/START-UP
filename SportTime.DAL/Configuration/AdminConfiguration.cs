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
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("admins");
            builder.HasKey(builder => builder.AdminId);
            builder.Property(a => a.AdminId).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(30);
            builder.Property(a => a.Number).IsRequired().HasMaxLength(9);
            builder.Property(a => a.Password).IsRequired().HasMaxLength(30);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(30);
        }
    }
}
