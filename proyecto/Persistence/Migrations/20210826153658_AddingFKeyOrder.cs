using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddingFKeyOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedido_Pedido_PedidoidPedido",
                table: "DetallePedido");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedido_PedidoidPedido",
                table: "DetallePedido");

            migrationBuilder.DropColumn(
                name: "PedidoidPedido",
                table: "DetallePedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_idPedido",
                table: "DetallePedido",
                column: "idPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedido_Pedido_idPedido",
                table: "DetallePedido",
                column: "idPedido",
                principalTable: "Pedido",
                principalColumn: "idPedido",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedido_Pedido_idPedido",
                table: "DetallePedido");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedido_idPedido",
                table: "DetallePedido");

            migrationBuilder.AddColumn<int>(
                name: "PedidoidPedido",
                table: "DetallePedido",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_PedidoidPedido",
                table: "DetallePedido",
                column: "PedidoidPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedido_Pedido_PedidoidPedido",
                table: "DetallePedido",
                column: "PedidoidPedido",
                principalTable: "Pedido",
                principalColumn: "idPedido",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
