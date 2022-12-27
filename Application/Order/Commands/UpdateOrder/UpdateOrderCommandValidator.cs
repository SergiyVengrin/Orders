using FluentValidation;

namespace Application.Order.Commands.UpdateOrder
{
    public sealed class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(p=>p.UserId)
                .GreaterThan(0).Unless(p=>p.UserId is null);

            RuleFor(p=>p.OrderCost)
                .GreaterThan(0).Unless(p=>p.OrderCost is null);

            RuleFor(p => p.ItemsDescription)
                .Length(2, 1000).Unless(p => string.IsNullOrEmpty(p.ItemsDescription));

            RuleFor(p => p.ShippingAddress)
               .Length(2, 1000).Unless(p => string.IsNullOrEmpty(p.ShippingAddress));
        }
    }
}
