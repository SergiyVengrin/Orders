using MediatR;

namespace Application.Order.Commands.CreateOrder
{
    public sealed class CreateOrderCommand:IRequest
    {
        public int UserId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? OrderCost { get; set; }
        public string? ItemsDescription { get; set; }
        public string? ShippingAddress { get; set; }
    }
}
