using FluentValidation;

namespace Application.User.Commands.CreateUser
{
    public sealed class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Login)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} should not be empty.")
                .Length(1, 20);

            RuleFor(p => p.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} should not be empty.")
                .Length(8, 50);

            RuleFor(p => p.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} should not be empty.")
                .Length(2, 40)
                .Must(IsValidName).WithMessage("{PropertyName} is not valid.");

            RuleFor(p => p.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} should not be empty.")
                .Length(2, 40)
                .Must(IsValidName).WithMessage("{PropertyName} is not valid.");

            RuleFor(p => p.DateOfBirth)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} should not be empty.");

            RuleFor(p => p.Gender)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidGender).WithMessage("{PropertyName} should be F, M or null");
                
        }

        private bool IsValidName(string name)
        {
            if (!name.All(Char.IsLetter))
            {
                return false;
            }
            if (!char.IsUpper(name[0]))
            {
                return false;
            }

            return true;
        }


        private bool IsValidGender(string? gender)
        {
            if(gender == null)
            {
                return true;
            }

            return gender.Equals("M") || gender.Equals("F");
        }
    }
}
