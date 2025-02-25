using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportTime.DAL.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "users");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "users",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "users",
                type: "int",
                maxLength: 9,
                nullable: false,
                defaultValue: 0);
        }
    }
}
