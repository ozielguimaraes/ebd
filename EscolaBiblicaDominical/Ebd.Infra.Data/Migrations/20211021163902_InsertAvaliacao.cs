using Microsoft.EntityFrameworkCore.Migrations;

namespace Ebd.Infra.Data.Migrations
{
    public partial class InsertAvaliacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Avaliacao",
                columns: new[] { "AvaliacaoId", "Nome", "Nota" },
                values: new object[,]
                {
                    { 1, "Presença", 2 },
                    { 2, "Trouxe visita?", 3 },
                    { 3, "Trouxe lição?", 2 },
                    { 4, "Trouxe bíblia?", 3 },
                    { 5, "Trouxe oferta?", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Avaliacao",
                keyColumn: "AvaliacaoId",
                keyValue: 1);
            migrationBuilder.DeleteData(
                table: "Avaliacao",
                keyColumn: "AvaliacaoId",
                keyValue: 2);
            migrationBuilder.DeleteData(
                table: "Avaliacao",
                keyColumn: "AvaliacaoId",
                keyValue: 3);
            migrationBuilder.DeleteData(
                table: "Avaliacao",
                keyColumn: "AvaliacaoId",
                keyValue: 4);
            migrationBuilder.DeleteData(
                table: "Avaliacao",
                keyColumn: "AvaliacaoId",
                keyValue: 5);
        }
    }
}
