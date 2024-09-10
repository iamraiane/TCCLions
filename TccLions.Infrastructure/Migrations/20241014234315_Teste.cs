using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccLions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissoes",
                keyColumn: "Id",
                keyValue: new Guid("7a466da1-2585-4933-9082-ed7c72dc3613"));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TipoDespesas",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEscrita",
                table: "Atas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeEvento = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    QuantidadeVenda = table.Column<int>(type: "int", unicode: false, nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    ValorTotal = table.Column<double>(type: "float", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Permissoes",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("9e96c444-48e6-4cde-a84d-da4e4f30d4f5"), "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Membros_Email",
                table: "Membros",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Membros_Email",
                table: "Membros");

            migrationBuilder.DeleteData(
                table: "Permissoes",
                keyColumn: "Id",
                keyValue: new Guid("9e96c444-48e6-4cde-a84d-da4e4f30d4f5"));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TipoDespesas",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataEscrita",
                table: "Atas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Permissoes",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("7a466da1-2585-4933-9082-ed7c72dc3613"), "Admin" });
        }
    }
}
