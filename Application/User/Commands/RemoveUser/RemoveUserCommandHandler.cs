using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Commands.RemoveUser
{
    public sealed class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, int>
    {
        private readonly IOrdersDbContext _db;

        public RemoveUserCommandHandler(IOrdersDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.SingleOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

            if (user is null)
            {
                throw new NotFoundException(request.UserId);
            }

            var orders = await _db.Orders.Where(o => o.UserId == request.UserId).ToListAsync(cancellationToken);

            if (orders.Any())
            {
                throw new ForbiddenException(request.UserId);
            }

            _db.Users.Remove(user);
            await _db.SaveChangesAsync(cancellationToken);

            return request.UserId;
        }
    }
}
