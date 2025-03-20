using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deliver.Data.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Roules",
                table: "Deliveries",
                newName: "Roles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Roles",
                table: "Deliveries",
                newName: "Roules");
        }
    }
}
