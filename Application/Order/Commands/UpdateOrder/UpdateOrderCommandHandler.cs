using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Order.Commands.UpdateOrder
{
    public sealed class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IOrdersDbContext _db;

        public UpdateOrderCommandHandler(IOrdersDbContext db)
        {
            _db = db;
        }


        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _db.Orders.SingleOrDefaultAsync(o => o.OrderId == request.OrderId, cancellationToken);

            if (order is null)
            {
                throw new NotFoundException(request.OrderId);
            }

            order.UserId = request.UserId ?? order.UserId;
            order.OrderDate = request.OrderDate ?? order.OrderDate;
            order.OrderCost = request.OrderCost ?? order.OrderCost;
            order.ItemsDescription = request.ItemsDescription ?? order.ItemsDescription;
            order.ShippingAddress = request.ShippingAddress ?? order.ShippingAddress;

            await _db.SaveChangesAsync(cancellationToken);

            return request.OrderId;
        }
    }
}
