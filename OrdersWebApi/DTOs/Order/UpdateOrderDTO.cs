namespace OrdersWebApi.DTOs.Order
{
    public sealed class UpdateOrderDTO
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? OrderCost { get; set; }
        public string? ItemsDescription { get; set; }
        public string? ShippingAddress { get; set; }
    }
}
