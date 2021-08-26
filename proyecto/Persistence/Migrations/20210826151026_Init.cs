using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.idProducto);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUduario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUduario);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    idPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(name: "Fecha Registro", type: "datetime2", nullable: false),
                    clientePedidoidCliente = table.Column<int>(type: "int", nullable: true),
                    idCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.idPedido);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_clientePedidoidCliente",
                        column: x => x.clientePedidoidCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ControlAprobacionPedido",
                columns: table => new
                {
                    idControlDeAprobacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    idPedido = table.Column<int>(type: "int", nullable: false),
                    idPedido1 = table.Column<int>(type: "int", nullable: false),
                    UsuarioidUduario = table.Column<int>(type: "int", nullable: true),
                    PedidoidPedido = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlAprobacionPedido", x => x.idControlDeAprobacion);
                    table.ForeignKey(
                        name: "FK_ControlAprobacionPedido_Pedido_PedidoidPedido",
                        column: x => x.PedidoidPedido,
                        principalTable: "Pedido",
                        principalColumn: "idPedido",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlAprobacionPedido_Usuario_UsuarioidUduario",
                        column: x => x.UsuarioidUduario,
                        principalTable: "Usuario",
                        principalColumn: "idUduario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    idDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoidProducto = table.Column<int>(type: "int", nullable: true),
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<long>(type: "bigint", nullable: false),
                    PedidoidPedido = table.Column<int>(type: "int", nullable: true),
                    idPedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedido", x => x.idDetalle);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Pedido_PedidoidPedido",
                        column: x => x.PedidoidPedido,
                        principalTable: "Pedido",
                        principalColumn: "idPedido",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Producto_ProductoidProducto",
                        column: x => x.ProductoidProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlAprobacionPedido_PedidoidPedido",
                table: "ControlAprobacionPedido",
                column: "PedidoidPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ControlAprobacionPedido_UsuarioidUduario",
                table: "ControlAprobacionPedido",
                column: "UsuarioidUduario");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_PedidoidPedido",
                table: "DetallePedido",
                column: "PedidoidPedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_ProductoidProducto",
                table: "DetallePedido",
                column: "ProductoidProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_clientePedidoidCliente",
                table: "Pedido",
                column: "clientePedidoidCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlAprobacionPedido");

            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
