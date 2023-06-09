using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smsark.Migrations
{
    /// <inheritdoc />
    public partial class photos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photos",
                table: "apartments",
                newName: "ThirdPhoto");

            migrationBuilder.AddColumn<string>(
                name: "FourthPhoto",
                table: "apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainPhoto",
                table: "apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecPhoto",
                table: "apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FourthPhoto",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "MainPhoto",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "SecPhoto",
                table: "apartments");

            migrationBuilder.RenameColumn(
                name: "ThirdPhoto",
                table: "apartments",
                newName: "Photos");
        }
    }
}
