using Application.Interfaces;
using Domain.Models;
using Infrastructure.Persistence.Configurations;
using Infrastructure.Persistence.Extentions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityContext
{
    public sealed class OrdersDbContext : DbContext, IOrdersDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.Seed();
        }
    }
}
