using Application.Order.Commands.UpdateOrder;
using Microsoft.EntityFrameworkCore;
using Tests.Common;

namespace Tests.Orders.Commands
{
    public class UpdateOrderCommandHandlerTests : TestCommandBase
    {

        [Fact]
            public async Task UpdateOrderCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateOrderCommandHandler(context);
            var orderId = 1;
            var userId = 1;
            var orderDate = new DateTime(2022, 12, 27, 12, 15, 0);
            var orderCost = 300;
            var itemsDescription = "Test";
            var shippingAddress = "Test";

            // Act
            await handler.Handle(new UpdateOrderCommand
            {
                OrderId = orderId,
                UserId = userId,
                OrderDate = null,
                OrderCost = orderCost,
                ItemsDescription = itemsDescription,
                ShippingAddress = shippingAddress
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await context.Orders.SingleOrDefaultAsync(o =>
                                                        o.OrderId == orderId
                                                        && o.UserId == userId
                                                        && o.OrderDate == orderDate
                                                        && o.OrderCost == orderCost
                                                        && o.ItemsDescription == itemsDescription
                                                        && o.ShippingAddress == shippingAddress
            ));
        }
    }
}
