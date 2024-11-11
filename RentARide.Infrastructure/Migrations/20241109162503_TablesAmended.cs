using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentARide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TablesAmended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Categories_CategoryId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Manufacturers_ManufacturerId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<short>(
                name: "Year",
                table: "Vehicles",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "HorsePower",
                table: "Vehicles",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Vehicles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Categories_CategoryId",
                table: "Vehicles",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Manufacturers_ManufacturerId",
                table: "Vehicles",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Categories_CategoryId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Manufacturers_ManufacturerId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Vehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "HorsePower",
                table: "Vehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Categories_CategoryId",
                table: "Vehicles",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Manufacturers_ManufacturerId",
                table: "Vehicles",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
