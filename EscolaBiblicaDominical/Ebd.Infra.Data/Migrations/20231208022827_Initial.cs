using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebd.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
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
                name: "Bairro",
                columns: table => new
                {
                    BairroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bairro", x => x.BairroId);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WhatsappIgualCelular = table.Column<bool>(type: "bit", nullable: false),
                    NascidoEm = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IdadeMinima = table.Column<int>(type: "int", nullable: false),
                    IdadeMaxima = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.TurmaId);
                });

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    ContatoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Classificacao = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.ContatoId);
                    table.ForeignKey(
                        name: "FK_Contato_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classificacao = table.Column<int>(type: "int", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    BairroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Endereco_Bairro_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairro",
                        principalColumn: "BairroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Endereco_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.AlunoId);
                    table.ForeignKey(
                        name: "FK_Aluno_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aluno_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turma",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfessorId);
                    table.ForeignKey(
                        name: "FK_Professor_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Professor_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turma",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revista",
                columns: table => new
                {
                    RevistaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sumario = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    RemoverDepois = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Trimestre = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revista", x => x.RevistaId);
                    table.ForeignKey(
                        name: "FK_Revista_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turma",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponsavelAluno",
                columns: table => new
                {
                    ResponsavelAlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoResponsavel = table.Column<int>(type: "int", nullable: false),
                    ResponsavelId = table.Column<int>(type: "int", nullable: false),
                    ResponsavelPessoaId = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsavelAluno", x => x.ResponsavelAlunoId);
                    table.ForeignKey(
                        name: "FK_ResponsavelAluno_Aluno_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponsavelAluno_Pessoa_ResponsavelPessoaId",
                        column: x => x.ResponsavelPessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Licao",
                columns: table => new
                {
                    LicaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    RevistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licao", x => x.LicaoId);
                    table.ForeignKey(
                        name: "FK_Licao_Revista_RevistaId",
                        column: x => x.RevistaId,
                        principalTable: "Revista",
                        principalColumn: "RevistaId");
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoAluno",
                columns: table => new
                {
                    AvaliacaoAlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    LicaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoAluno", x => x.AvaliacaoAlunoId);
                    table.ForeignKey(
                        name: "FK_AvaliacaoAluno_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId");
                    table.ForeignKey(
                        name: "FK_AvaliacaoAluno_Avaliacao_AvaliacaoId",
                        column: x => x.AvaliacaoId,
                        principalTable: "Avaliacao",
                        principalColumn: "AvaliacaoId");
                    table.ForeignKey(
                        name: "FK_AvaliacaoAluno_Licao_LicaoId",
                        column: x => x.LicaoId,
                        principalTable: "Licao",
                        principalColumn: "LicaoId");
                });

            migrationBuilder.CreateTable(
                name: "Chamada",
                columns: table => new
                {
                    ChamadaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstavaPresente = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    LicaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamada", x => x.ChamadaId);
                    table.ForeignKey(
                        name: "FK_Chamada_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chamada_Licao_LicaoId",
                        column: x => x.LicaoId,
                        principalTable: "Licao",
                        principalColumn: "LicaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_PessoaId",
                table: "Aluno",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_TurmaId",
                table: "Aluno",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoAluno_AlunoId",
                table: "AvaliacaoAluno",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoAluno_AvaliacaoId",
                table: "AvaliacaoAluno",
                column: "AvaliacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoAluno_LicaoId",
                table: "AvaliacaoAluno",
                column: "LicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bairro_Nome",
                table: "Bairro",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Chamada_AlunoId",
                table: "Chamada",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamada_LicaoId",
                table: "Chamada",
                column: "LicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contato_PessoaId",
                table: "Contato",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_BairroId",
                table: "Endereco",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PessoaId",
                table: "Endereco",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Licao_RevistaId",
                table: "Licao",
                column: "RevistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Nome",
                table: "Pessoa",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_PessoaId",
                table: "Professor",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_TurmaId",
                table: "Professor",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsavelAluno_ResponsavelId",
                table: "ResponsavelAluno",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsavelAluno_ResponsavelPessoaId",
                table: "ResponsavelAluno",
                column: "ResponsavelPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Revista_Ano_Trimestre",
                table: "Revista",
                columns: new[] { "Ano", "Trimestre" });

            migrationBuilder.CreateIndex(
                name: "IX_Revista_TurmaId",
                table: "Revista",
                column: "TurmaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoAluno");

            migrationBuilder.DropTable(
                name: "Chamada");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "ResponsavelAluno");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Licao");

            migrationBuilder.DropTable(
                name: "Bairro");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Revista");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Turma");
        }
    }
}
