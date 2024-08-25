using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TccLions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosCivis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosCivis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoComissoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoComissoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Endereco = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Cep = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    EstadoCivilId = table.Column<int>(type: "int", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membros_EstadosCivis_EstadoCivilId",
                        column: x => x.EstadoCivilId,
                        principalTable: "EstadosCivis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comissoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoComissaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comissoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comissoes_Membros_MembroId",
                        column: x => x.MembroId,
                        principalTable: "Membros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comissoes_TipoComissoes_TipoComissaoId",
                        column: x => x.TipoComissaoId,
                        principalTable: "TipoComissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadosCivis",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 0, "Solteiro" },
                    { 1, "Casado" },
                    { 2, "Separado" },
                    { 3, "Divorciado" },
                    { 4, "Viuvo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comissoes_MembroId",
                table: "Comissoes",
                column: "MembroId");

            migrationBuilder.CreateIndex(
                name: "IX_Comissoes_TipoComissaoId",
                table: "Comissoes",
                column: "TipoComissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Membros_EstadoCivilId",
                table: "Membros",
                column: "EstadoCivilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comissoes");

            migrationBuilder.DropTable(
                name: "Membros");

            migrationBuilder.DropTable(
                name: "TipoComissoes");

            migrationBuilder.DropTable(
                name: "EstadosCivis");
        }
    }
}
