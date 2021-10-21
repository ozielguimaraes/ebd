using Microsoft.EntityFrameworkCore.Migrations;

namespace Ebd.Infra.Data.Migrations
{
    public partial class AdicionarTabelaAvaliacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoAluno",
                columns: table => new
                {
                    AvaliacaoAlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoAluno", x => x.AvaliacaoAlunoId);
                    table.ForeignKey(
                        name: "FK_AvaliacaoAluno_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvaliacaoAluno_Avaliacao_AvaliacaoId",
                        column: x => x.AvaliacaoId,
                        principalTable: "Avaliacao",
                        principalColumn: "AvaliacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoAluno_AlunoId",
                table: "AvaliacaoAluno",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoAluno_AvaliacaoId",
                table: "AvaliacaoAluno",
                column: "AvaliacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoAluno");

            migrationBuilder.DropTable(
                name: "Avaliacao");
            
            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "TurmaId", "IdadeMaxima", "IdadeMinima", "Nome" },
                values: new object[,]
                {
                    { 2, 14, 13, "Adolescentes Vencedores" },
                    { 1, 12, 11, "Mensageiros da Fé" },
                    { 3, 17, 15, "Campeões da Fé" }
                });
        }
    }
}
