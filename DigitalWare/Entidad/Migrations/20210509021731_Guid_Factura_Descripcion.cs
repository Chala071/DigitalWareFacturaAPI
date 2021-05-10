using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entidad.Migrations
{
    public partial class Guid_Factura_Descripcion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "DescripcionFactura");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    FacturaId = table.Column<Guid>(nullable: false),
                    FacturaFecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    ClienteId = table.Column<long>(nullable: false),
                    FacturaIVAPorcentaje = table.Column<decimal>(type: "decimal(4, 2)", nullable: false),
                    FacturaSubtotal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FacturaTotal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FacturaIVATotal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.FacturaId);
                    table.ForeignKey(
                        name: "FK_Factura_Cliente",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DescripcionFactura",
                columns: table => new
                {
                    DescripcionFacturaId = table.Column<Guid>(nullable: false),
                    DescripcionFacturaCantidad = table.Column<int>(nullable: true),
                    DescripcionFacturaPrecio = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    FacturaId = table.Column<Guid>(nullable: true),
                    ProductoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescripcionFactura", x => x.DescripcionFacturaId);
                    table.ForeignKey(
                        name: "FK_DescripcionFactura_Factura",
                        column: x => x.FacturaId,
                        principalTable: "Factura",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DescripcionFactura_Producto",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DescripcionFactura_FacturaId",
                table: "DescripcionFactura",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_DescripcionFactura_ProductoId",
                table: "DescripcionFactura",
                column: "ProductoId");

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescripcionFactura");

            migrationBuilder.DropTable(
                name: "Factura");

            /*migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Categoria");*/
        }
    }
}
