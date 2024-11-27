using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentARide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeededTest5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 3, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c85d56c1-8bff-4744-9afd-978c7cbbf525", "AQAAAAIAAYagAAAAECxAP7YcLjw9UqGebxqq5XapXNnt9MhAARXpf6ucRII/7uf9QaJV4z80KIOOt2ZpJg==", "202e4eac-e442-4fa3-813e-14b4bff6004f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "badf89d9-076d-40d9-81e4-ac460fd874cf", "AQAAAAIAAYagAAAAEIBXcG0kSUtmTXIeVqU3wG7mKxtXiPVGlrq9T6s7Uegmmlpu7ZQDWIhibwwDA9kXgA==", "ae80ec6e-390d-4b33-aa0c-f6cce845fc9a" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "AgentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "AgentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "AgentId",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c8d5d50-1cd9-4153-829c-de141252db66", "AQAAAAIAAYagAAAAEPmbvWKOgVUrLZTotJPFZKh7ISd2XEkOxuS9FXyrEoYAd6QlMM+4A4naWN1H/wV0aw==", "7045ea9c-338a-4ffb-80b4-dd156b68b1e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b63f02a-c526-41b1-97b5-7297e8aaf517", "AQAAAAIAAYagAAAAEOtgFUS5o1PYwyQK6X6bx6l8jsraqYdAFaZKSdjtot9C8CYQNOdi2y6LkHSONz02NQ==", "c7cb822b-13a0-416d-a28e-6bfad4c38028" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "AgentId",
                value: 1);
        }
    }
}
