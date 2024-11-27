using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentARide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeededTest4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "8c8d5d50-1cd9-4153-829c-de141252db66", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAIAAYagAAAAEPmbvWKOgVUrLZTotJPFZKh7ISd2XEkOxuS9FXyrEoYAd6QlMM+4A4naWN1H/wV0aw==", null, false, "7045ea9c-338a-4ffb-80b4-dd156b68b1e5", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "0b63f02a-c526-41b1-97b5-7297e8aaf517", "agent@mail.com", false, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAIAAYagAAAAEOtgFUS5o1PYwyQK6X6bx6l8jsraqYdAFaZKSdjtot9C8CYQNOdi2y6LkHSONz02NQ==", null, false, "c7cb822b-13a0-416d-a28e-6bfad4c38028", false, "agent@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hatchback" },
                    { 2, "Wagon" },
                    { 3, "Suv" },
                    { 4, "Sedan" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Diesel" },
                    { 2, "Petrol" },
                    { 3, "Hybrid" },
                    { 4, "Electric" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Audi" },
                    { 2, "Honda" },
                    { 3, "VW" },
                    { 4, "Mercedes" },
                    { 5, "Hyundai" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "AgentId", "CategoryId", "Description", "EngineId", "HorsePower", "ImageUrl", "ManufacturerId", "Model", "PricePerDay", "RenterId", "Year" },
                values: new object[,]
                {
                    { 1, 1, 1, "A small diesel efficient Hatchback produced by Audi. Extremely reliable vehicle that is cheap to mantain", 1, (short)150, "https://uploads.audi-mediacenter.com/system/production/media/90567/images/72391bd2d21a80a761f0df1bd5bff197d5804daa/A201895_blog.jpg?1698421086", 1, "A3", 100.00m, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", (short)2020 },
                    { 2, 1, 4, "A mid size sedan produced by Honda. Extremely reliable vehicle that is cheap to mantain", 2, (short)190, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRz9gv29Fkt4YY3iFnTLgG-lyKErfmnHrmeZg&s", 2, "Accord", 150.00m, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", (short)2018 },
                    { 3, 1, 4, "A big sedan produced by Mercedes-Benz. Extremely reliable vehicle that costly to maintain", 3, (short)272, "https://www.jonathanmotorcars.com/imagetag/80/main/l/Used-2011-Mercedes-Benz-E-Class-E350-Sedan-4MATIC-1500582553.jpg", 4, "E350", 130.00m, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", (short)2011 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
