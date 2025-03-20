using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deliver.Data.Migrations
{
    public partial class roules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Roules",
                table: "Deliveries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roules",
                table: "Deliveries");
        }
    }
}
