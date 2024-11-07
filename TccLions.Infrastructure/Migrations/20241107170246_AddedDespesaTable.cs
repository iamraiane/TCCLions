using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccLions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedDespesaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissoes",
                keyColumn: "Id",
                keyValue: new Guid("9e96c444-48e6-4cde-a84d-da4e4f30d4f5"));

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataVencimento = table.Column<DateOnly>(type: "date", nullable: false),
                    DataRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false),
                    TipoDeDespesaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembroId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesas_Membros_MembroId",
                        column: x => x.MembroId,
                        principalTable: "Membros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Despesas_TipoDespesas_TipoDeDespesaId",
                        column: x => x.TipoDeDespesaId,
                        principalTable: "TipoDespesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissoes",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("0c60c946-51e8-4e71-9b00-2666bc360d15"), "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_MembroId",
                table: "Despesas",
                column: "MembroId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_TipoDeDespesaId",
                table: "Despesas",
                column: "TipoDeDespesaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DeleteData(
                table: "Permissoes",
                keyColumn: "Id",
                keyValue: new Guid("0c60c946-51e8-4e71-9b00-2666bc360d15"));

            migrationBuilder.InsertData(
                table: "Permissoes",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("9e96c444-48e6-4cde-a84d-da4e4f30d4f5"), "Admin" });
        }
    }
}
