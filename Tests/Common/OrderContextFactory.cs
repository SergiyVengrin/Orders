using Infrastructure.Persistence.EntityContext;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Tests.Common
{
    public class OrderContextFactory
    {
        public static int userAId = 1;
        public static int userBId = 2;

        public static int orderIdForDelete = 1;
        public static int orderIdForUpdate = 2;


        public static OrdersDbContext Create()
        {
            var options = new DbContextOptionsBuilder<OrdersDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new OrdersDbContext(options);
            context.Database.EnsureCreated();

            context.Users.AddRange(
                new User
                {
                    UserId = 1,
                    Login = "alex22",
                    Password = "$2a$11$PfkrgvNcDNvvQjht5z7xk.3QkggaRme5vNERKFAasDzuPtjfZx5oe",
                    FirstName = "Alex",
                    LastName = "Dane",
                    DateOfBirth = new DateTime(2002, 12, 12),
                    Gender = "M"
                },
                new User
                {
                    UserId = 2,
                    Login = "sergiy19",
                    Password = "$2a$11$oOlmOVB8CuJ6v2t1VMRpmeJfhWwCDf05aMSGO9CJDYh9Ud34QaN0O",
                    FirstName = "Sergiy",
                    LastName = "Vengrin",
                    DateOfBirth = new DateTime(2003, 02, 19),
                    Gender = "M"
                },
                new User
                {
                    UserId = 3,
                    Login = "john44",
                    Password = "$2a$11$oOlmOVB8Cud6v2t1VMRpmeJfhWwCDf05aMSGO9CJDYh9Ud34QaN0O",
                    FirstName = "John",
                    LastName = "King",
                    DateOfBirth = new DateTime(2001, 02, 02),
                    Gender = null
                });

            context.Orders.AddRange(
                new Order
                {
                    OrderId = 1,
                    UserId = 1,
                    OrderDate = new DateTime(2022, 12, 27, 12, 15, 0),
                    OrderCost = 155,
                    ItemsDescription = "Redmibook pro 14 Ryzen 5",
                    ShippingAddress = "Ukraine, Lviv, Hazova 14"
                },
                new Order
                {
                    OrderId = 2,
                    UserId = 1,
                    OrderDate = new DateTime(2022, 12, 25, 16, 5, 0),
                    OrderCost = 1005,
                    ItemsDescription = "Samsung TV",
                    ShippingAddress = "Ukraine, Lviv, Naukova 14"
                },
                new Order
                {
                    OrderId = 3,
                    UserId = 2,
                    OrderDate = new DateTime(2022, 12, 27, 10, 30, 33),
                    OrderCost = 537,
                    ItemsDescription = "Christmas tree",
                    ShippingAddress = "Ukraine, Lviv, Horodotska 1"
                });

            context.SaveChanges();

            return context;
        }


        public static void Destroy(OrdersDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
