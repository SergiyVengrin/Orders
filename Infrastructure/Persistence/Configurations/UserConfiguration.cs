using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(e => e.Login, "UQ_user_login")
                .IsUnique();

            builder.Property(e => e.DateOfBirth).HasColumnType("date");

            builder.Property(e => e.FirstName)
                .HasMaxLength(40)
                .IsUnicode(false);

            builder.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false);

            builder.Property(e => e.LastName)
                .HasMaxLength(40)
                .IsUnicode(false);

            builder.Property(e => e.Login)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
