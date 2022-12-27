using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "FirstName", "Gender", "LastName", "Login", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "M", "Dane", "alex22", "$2a$11$PfkrgvNcDNvvQjht5z7xk.3QkggaRme5vNERKFAasDzuPtjfZx5oe" },
                    { 2, new DateTime(2003, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiy", "M", "Vengrin", "sergiy19", "$2a$11$oOlmOVB8CuJ6v2t1VMRpmeJfhWwCDf05aMSGO9CJDYh9Ud34QaN0O" },
                    { 3, new DateTime(2001, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", null, "King", "john44", "$2a$11$oOlmOVB8Cud6v2t1VMRpmeJfhWwCDf05aMSGO9CJDYh9Ud34QaN0O" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "ItemsDescription", "OrderCost", "OrderDate", "ShippingAddress", "UserId" },
                values: new object[,]
                {
                    { 1, "Redmibook pro 14 Ryzen 5", 155m, new DateTime(2022, 12, 27, 12, 15, 0, 0, DateTimeKind.Unspecified), "Ukraine, Lviv, Hazova 14", 1 },
                    { 2, "Samsung TV", 1005m, new DateTime(2022, 12, 25, 16, 5, 0, 0, DateTimeKind.Unspecified), "Ukraine, Lviv, Naukova 14", 1 },
                    { 3, "Christmas tree", 537m, new DateTime(2022, 12, 27, 10, 30, 33, 0, DateTimeKind.Unspecified), "Ukraine, Lviv, Horodotska 1", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
