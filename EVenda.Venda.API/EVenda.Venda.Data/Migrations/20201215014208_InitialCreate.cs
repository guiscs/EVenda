using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVenda.Venda.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sku = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    QtdEstoque = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
