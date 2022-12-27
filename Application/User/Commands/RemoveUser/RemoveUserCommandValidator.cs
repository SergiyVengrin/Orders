using FluentValidation;

namespace Application.User.Commands.RemoveUser
{
    public sealed class RemoveUserCommandValidator : AbstractValidator<RemoveUserCommand>
    {
        public RemoveUserCommandValidator()
        {
            RuleFor(p => p.UserId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} should not be empty.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0");
        }
    }
}
