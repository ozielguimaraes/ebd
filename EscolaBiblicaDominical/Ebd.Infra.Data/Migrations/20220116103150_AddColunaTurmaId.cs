using Microsoft.EntityFrameworkCore.Migrations;

namespace Ebd.Infra.Data.Migrations
{
    public partial class AddColunaTurmaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurmaId",
                table: "Revista",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Revista_TurmaId",
                table: "Revista",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Revista_Turma_TurmaId",
                table: "Revista",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "TurmaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revista_Turma_TurmaId",
                table: "Revista");

            migrationBuilder.DropIndex(
                name: "IX_Revista_TurmaId",
                table: "Revista");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Revista");
        }
    }
}
