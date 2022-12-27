using Application.Interfaces;
using MediatR;

namespace Application.Order.Commands.CreateOrder
{
    public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrdersDbContext _db;

        public CreateOrderCommandHandler(IOrdersDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Domain.Models.Order
            {
                UserId = request.UserId,
                OrderDate = request.OrderDate,
                OrderCost = request.OrderCost,
                ItemsDescription = request.ItemsDescription,
                ShippingAddress = request.ShippingAddress
            };

            await _db.Orders.AddAsync(order, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
