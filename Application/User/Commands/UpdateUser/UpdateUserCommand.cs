using MediatR;

namespace Application.User.Commands.UpdateUser
{
    public sealed class UpdateUserCommand:IRequest<int>
    {
        public int UserId { get; set; }
        public string? Login { get; set; } 
        public string? Password { get; set; }
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
    }
}
