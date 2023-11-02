using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Release_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "releases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descricao = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    valor = table.Column<decimal>(type: "TEXT", precision: 14, scale: 2, nullable: false),
                    avulso = table.Column<string>(type: "TEXT", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_releases", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "releases",
                columns: new[] { "Id", "avulso", "data", "descricao", "status", "valor" },
                values: new object[,]
                {
                    { 1, "Válido", new DateTime(2023, 10, 30, 19, 33, 17, 458, DateTimeKind.Local).AddTicks(1790), "Teste 1", "Válido", 10m },
                    { 2, "Não Avulso", new DateTime(2023, 10, 30, 19, 33, 17, 458, DateTimeKind.Local).AddTicks(1824), "Teste 2", "Cancelado", 20m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "releases");
        }
    }
}
