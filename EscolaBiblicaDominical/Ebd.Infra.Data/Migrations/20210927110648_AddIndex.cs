using Microsoft.EntityFrameworkCore.Migrations;

namespace Ebd.Infra.Data.Migrations
{
    public partial class AddIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Revista_Ano_Trimestre",
                table: "Revista",
                columns: new[] { "Ano", "Trimestre" });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Nome",
                table: "Pessoa",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Bairro_Nome",
                table: "Bairro",
                column: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Revista_Ano_Trimestre",
                table: "Revista");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_Nome",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Bairro_Nome",
                table: "Bairro");
        }
    }
}
