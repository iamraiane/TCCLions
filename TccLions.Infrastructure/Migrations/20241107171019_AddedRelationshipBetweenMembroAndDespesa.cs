using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccLions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationshipBetweenMembroAndDespesa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Membros_MembroId",
                table: "Despesas");

            migrationBuilder.DeleteData(
                table: "Permissoes",
                keyColumn: "Id",
                keyValue: new Guid("0c60c946-51e8-4e71-9b00-2666bc360d15"));

            migrationBuilder.AlterColumn<Guid>(
                name: "MembroId",
                table: "Despesas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Permissoes",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("90190963-154b-4add-89a0-775dd7f69d1d"), "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Membros_MembroId",
                table: "Despesas",
                column: "MembroId",
                principalTable: "Membros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Membros_MembroId",
                table: "Despesas");

            migrationBuilder.DeleteData(
                table: "Permissoes",
                keyColumn: "Id",
                keyValue: new Guid("90190963-154b-4add-89a0-775dd7f69d1d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "MembroId",
                table: "Despesas",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Permissoes",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("0c60c946-51e8-4e71-9b00-2666bc360d15"), "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Membros_MembroId",
                table: "Despesas",
                column: "MembroId",
                principalTable: "Membros",
                principalColumn: "Id");
        }
    }
}
