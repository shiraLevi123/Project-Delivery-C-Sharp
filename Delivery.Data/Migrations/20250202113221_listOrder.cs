using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deliver.Data.Migrations
{
    public partial class listOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deliveries_DeliverId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliverId",
                table: "Orders");
        }
    }
}
