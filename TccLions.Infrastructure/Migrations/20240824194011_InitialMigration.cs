using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccLions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Endereco = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Cep = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    EstadoCivil = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membro", x => x.Id);
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
                        name: "FK_Comissoes_Membro_MembroId",
                        column: x => x.MembroId,
                        principalTable: "Membro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comissoes_TipoComissoes_TipoComissaoId",
                        column: x => x.TipoComissaoId,
                        principalTable: "TipoComissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comissoes_MembroId",
                table: "Comissoes",
                column: "MembroId");

            migrationBuilder.CreateIndex(
                name: "IX_Comissoes_TipoComissaoId",
                table: "Comissoes",
                column: "TipoComissaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comissoes");

            migrationBuilder.DropTable(
                name: "Membro");

            migrationBuilder.DropTable(
                name: "TipoComissoes");
        }
    }
}
