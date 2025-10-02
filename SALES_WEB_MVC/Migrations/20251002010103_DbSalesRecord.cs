using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SALES_WEB_MVC.Migrations
{
    /// <inheritdoc />
    public partial class DbSalesRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SellerVendedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseSalário = table.Column<double>(type: "float", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerVendedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellerVendedores_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesRecorde",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountQuantidade = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SellerVendedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRecorde", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesRecorde_SellerVendedores_SellerVendedorId",
                        column: x => x.SellerVendedorId,
                        principalTable: "SellerVendedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesRecorde_SellerVendedorId",
                table: "SalesRecorde",
                column: "SellerVendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerVendedores_DepartamentoId",
                table: "SellerVendedores",
                column: "DepartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesRecorde");

            migrationBuilder.DropTable(
                name: "SellerVendedores");
        }
    }
}
