using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebd.Infra.Data.Migrations
{
    public partial class ResponsavelAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Pessoa_ResponsavelId",
                table: "Aluno");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_ResponsavelId",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "ResponsavelId",
                table: "Aluno");

            migrationBuilder.CreateTable(
                name: "ResponsavelAluno",
                columns: table => new
                {
                    ResponsavelAlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoResponsavel = table.Column<int>(type: "int", nullable: false),
                    ResponsavelId = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    AlunoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsavelAluno", x => x.ResponsavelAlunoId);
                    table.ForeignKey(
                        name: "FK_ResponsavelAluno_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponsavelAluno_Aluno_AlunoId1",
                        column: x => x.AlunoId1,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId");
                    table.ForeignKey(
                        name: "FK_ResponsavelAluno_Pessoa_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResponsavelAluno_AlunoId",
                table: "ResponsavelAluno",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsavelAluno_AlunoId1",
                table: "ResponsavelAluno",
                column: "AlunoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsavelAluno_ResponsavelId",
                table: "ResponsavelAluno",
                column: "ResponsavelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponsavelAluno");

            migrationBuilder.AddColumn<int>(
                name: "ResponsavelId",
                table: "Aluno",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_ResponsavelId",
                table: "Aluno",
                column: "ResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Pessoa_ResponsavelId",
                table: "Aluno",
                column: "ResponsavelId",
                principalTable: "Pessoa",
                principalColumn: "PessoaId");
        }
    }
}
