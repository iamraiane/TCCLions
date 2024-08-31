using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TccLions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedPermissao : Migration
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
                name: "Permissoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.Id);
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
                name: "TipoDespesas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDespesas", x => x.Id);
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
                    Senha = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "MembroPermissoes",
                columns: table => new
                {
                    MembrosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembroPermissoes", x => new { x.MembrosId, x.PermissoesId });
                    table.ForeignKey(
                        name: "FK_MembroPermissoes_Membros_MembrosId",
                        column: x => x.MembrosId,
                        principalTable: "Membros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembroPermissoes_Permissoes_PermissoesId",
                        column: x => x.PermissoesId,
                        principalTable: "Permissoes",
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
                name: "IX_MembroPermissoes_PermissoesId",
                table: "MembroPermissoes",
                column: "PermissoesId");

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
                name: "MembroPermissoes");

            migrationBuilder.DropTable(
                name: "TipoDespesas");

            migrationBuilder.DropTable(
                name: "TipoComissoes");

            migrationBuilder.DropTable(
                name: "Membros");

            migrationBuilder.DropTable(
                name: "Permissoes");

            migrationBuilder.DropTable(
                name: "EstadosCivis");
        }
    }
}
