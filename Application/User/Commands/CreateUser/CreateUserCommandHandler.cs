using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Commands.CreateUser
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IOrdersDbContext _db;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserCommandHandler(IOrdersDbContext db, IPasswordHasher passwordHasher)
        {
            _db = db;
            _passwordHasher = passwordHasher;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.SingleOrDefaultAsync(u => u.Login == request.Login, cancellationToken);

            if (user is not null)
            {
                throw new ForbiddenException(user.Login);
            }


            var newUser = new Domain.Models.User
            {
                Login = request.Login,
                Password = _passwordHasher.HashPassword(request.Password),
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender
            };

            await _db.Users.AddAsync(newUser, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
