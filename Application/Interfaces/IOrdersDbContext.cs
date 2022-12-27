using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IOrdersDbContext
    {
        DbSet<Domain.Models.User> Users { get; set; }
        DbSet<Domain.Models.Order> Orders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
