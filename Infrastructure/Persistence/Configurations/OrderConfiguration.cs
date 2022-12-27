using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.ItemsDescription)
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.OrderCost).HasColumnType("money");

            builder.Property(e => e.OrderDate).HasColumnType("datetime");

            builder.Property(e => e.ShippingAddress)
                .HasMaxLength(1000)
                .IsUnicode(false);
        }
    }
}
