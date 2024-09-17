using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoManagementSystemProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Locacoes",
                table: "Locacoes");

            migrationBuilder.DropIndex(
                name: "IX_Locacoes_MotoId",
                table: "Locacoes");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Locacoes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locacoes",
                table: "Locacoes",
                columns: new[] { "MotoId", "EntregadorId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Locacoes",
                table: "Locacoes");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Locacoes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locacoes",
                table: "Locacoes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_MotoId",
                table: "Locacoes",
                column: "MotoId");
        }
    }
}
