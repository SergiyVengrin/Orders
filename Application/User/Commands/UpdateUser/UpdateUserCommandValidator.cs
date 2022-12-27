using FluentValidation;

namespace Application.User.Commands.UpdateUser
{
    public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(p => p.Login)
                .Length(2, 20).Unless(p => string.IsNullOrEmpty(p.Login));

            RuleFor(p => p.Password)
                .Length(8, 50).Unless(p => string.IsNullOrEmpty(p.Password));

            RuleFor(p => p.FirstName)
                .Cascade(CascadeMode.Stop)
                .Length(2, 40).Unless(p => string.IsNullOrEmpty(p.FirstName))
                .Must(IsValidName).WithMessage("{PropertyName} is not valid.");

            RuleFor(p => p.LastName)
                .Cascade(CascadeMode.Stop)
                .Length(2, 40).Unless(p => string.IsNullOrEmpty(p.LastName))
                .Must(IsValidName).WithMessage("{PropertyName} is not valid.");

            RuleFor(p => p.Gender)
                .Must(IsValidGender).WithMessage("{PropertyName} should be F, M or null");

        }

        private bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return true;
            }
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
            if (gender == null)
            {
                return true;
            }

            return gender.Equals("M") || gender.Equals("F");
        }
    }
}
