using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddActiveToDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Departments",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Departments");
        }
    }
}
