using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deliver.Data.Migrations
{
    public partial class express : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deliveries_DeliverId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliverId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Deliveries");

            migrationBuilder.AddColumn<bool>(
                name: "Express",
                table: "Deliveries",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Express",
                table: "Deliveries");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Deliveries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliverId",
                table: "Orders",
                column: "DeliverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deliveries_DeliverId",
                table: "Orders",
                column: "DeliverId",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
