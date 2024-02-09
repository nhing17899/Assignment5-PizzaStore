using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreDatabase.Migrations
{
    /// <inheritdoc />
    public partial class InitialRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItem_OrderId",
                table: "OrderLineItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItem_ProductId",
                table: "OrderLineItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItem_Orders_OrderId",
                table: "OrderLineItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItem_Products_ProductId",
                table: "OrderLineItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItem_Orders_OrderId",
                table: "OrderLineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItem_Products_ProductId",
                table: "OrderLineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderLineItem_OrderId",
                table: "OrderLineItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderLineItem_ProductId",
                table: "OrderLineItem");
        }
    }
}
