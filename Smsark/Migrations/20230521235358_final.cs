using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smsark.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "checkout",
                table: "reservations",
                newName: "Checkout");

            migrationBuilder.RenameColumn(
                name: "checkin",
                table: "reservations",
                newName: "Checkin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Checkout",
                table: "reservations",
                newName: "checkout");

            migrationBuilder.RenameColumn(
                name: "Checkin",
                table: "reservations",
                newName: "checkin");
        }
    }
}
