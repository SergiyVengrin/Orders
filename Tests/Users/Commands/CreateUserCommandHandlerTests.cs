using Application.User.Commands.CreateUser;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Tests.Common;

namespace Tests.Users.Commands
{
    public class CreateUserCommandHandlerTests : TestCommandBase
    {

        [Fact]
        public async Task CreateUserCommandHandler_Success()
        {
            // Arrange
            var passwordHasher = new PasswordHasher();
            var handler = new CreateUserCommandHandler(context, passwordHasher);
            var userLogin = "TestLogin";
            var userPassword = "TestPassword";
            var userFirstName = "Testname";
            var userLastName = "Testname";
            var userDateOfBirth = new DateTime(2000, 1, 1);
            var userGender = "M";

            // Act 
            await handler.Handle(new CreateUserCommand
            {
                Login = userLogin,
                Password = userPassword,
                FirstName = userFirstName,
                LastName = userLastName,
                DateOfBirth = userDateOfBirth,
                Gender = userGender
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await context.Users.SingleOrDefaultAsync(u => 
            u.Login == userLogin 
            && u.FirstName == userFirstName
            && u.LastName == userLastName
            && u.DateOfBirth == userDateOfBirth
            && u.Gender == userGender
            ));
        }
    }
}
