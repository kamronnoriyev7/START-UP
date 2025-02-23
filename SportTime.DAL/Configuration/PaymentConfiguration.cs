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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(builder => builder.PaymentId);
            builder.Property(x => x.PaymentId).ValueGeneratedOnAdd();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.PaymentStatus).IsRequired();
            builder.HasOne(p => p.User)
               .WithMany(u => u.Payments)
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.Cascade); // Agar User o‘chirilsa, uning to‘lovlari ham o‘chiriladi
        }
    }
}
