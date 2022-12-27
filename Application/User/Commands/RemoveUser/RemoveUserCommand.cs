using MediatR;

namespace Application.User.Commands.RemoveUser
{
    public sealed class RemoveUserCommand : IRequest<int>
    {
        public int UserId { get; set; }
    }
}
