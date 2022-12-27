using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Commands.UpdateUser
{
    public sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IOrdersDbContext _db;
        private readonly IPasswordHasher _passwordHasher;

        public UpdateUserCommandHandler(IOrdersDbContext db, IPasswordHasher passwordHasher)
        {
            _db = db;
            _passwordHasher = passwordHasher;
        }


        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.SingleOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

            if (user is null)
            {
                throw new NotFoundException(request.UserId);
            }

            user.UserId = user.UserId;
            user.Login = request.Login ?? user.Login;
            user.Password = _passwordHasher.HashPassword(request.Password) ?? user.Password;
            user.FirstName = request.FirstName ?? user.FirstName;
            user.LastName = request.LastName ?? user.LastName;
            user.DateOfBirth = request.DateOfBirth ?? user.DateOfBirth;
            user.Gender = request.Gender ?? user.Gender;

            await _db.SaveChangesAsync(cancellationToken);

            return request.UserId;
        }
    }
}
