using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CamarasFrias.Migrations
{
    public partial class IdentityKeyIdDetalleVenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Domicilio = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.DNI);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    Precio = table.Column<decimal>(type: "money", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    NroComprobante = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    PrecioFinal = table.Column<decimal>(type: "money", nullable: false),
                    Nota = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.NroComprobante);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "DNI");
                });

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PorcDescuento = table.Column<int>(type: "int", nullable: true),
                    Subtotal = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Productos",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Venta",
                        column: x => x.VentaId,
                        principalTable: "Venta",
                        principalColumn: "NroComprobante");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_ProductoId",
                table: "DetalleVenta",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_VentaId",
                table: "DetalleVenta",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ClienteId",
                table: "Venta",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
