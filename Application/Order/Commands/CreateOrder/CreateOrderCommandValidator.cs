using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Order.Commands.CreateOrder
{
    public sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(p => p.UserId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} should not be empty.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0.");

            RuleFor(p => p.OrderCost)
                .GreaterThan(0).Unless(p => p.OrderCost is null).WithMessage("{PropertyName} should be greater than 0.");

            RuleFor(p => p.ItemsDescription)
                .Length(2, 1000).Unless(p => string.IsNullOrEmpty(p.ItemsDescription));

            RuleFor(p => p.ShippingAddress)
               .Length(2, 1000).Unless(p => string.IsNullOrEmpty(p.ShippingAddress));
        }
    }
}
