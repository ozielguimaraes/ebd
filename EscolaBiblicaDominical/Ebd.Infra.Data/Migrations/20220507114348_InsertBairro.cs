using Microsoft.EntityFrameworkCore.Migrations;

namespace Ebd.Infra.Data.Migrations
{
    public partial class InsertBairro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bairro",
                columns: new[] { "BairroId", "Nome" },
                values: new object[,]
                {
                    { 1, "Aclimação" },
                    { 87, "Presidente Roosevelt" },
                    { 86, "Planalto" },
                    { 85, "Patrimônio" },
                    { 84, "Parque das Américas" },
                    { 83, "Parque Américas" },
                    { 82, "Panorama" },
                    { 81, "Pampulha" },
                    { 80, "Pacaembu" },
                    { 79, "Osvaldo Rezende" },
                    { 78, "Osvaldo Resende" },
                    { 77, "Novo Mundo" },
                    { 76, "Nova Uberlândia" },
                    { 74, "Nosso Recanto" },
                    { 73, "Nossa Sra Graças" },
                    { 72, "Nossa Senhora das Graças" },
                    { 71, "Nossa Senhora Aparecida" },
                    { 70, "Morumbi" },
                    { 69, "Morada Nova Ii" },
                    { 68, "Morada Nova" },
                    { 67, "Morada dos Pássaros" },
                    { 66, "Morada da Colina" },
                    { 65, "Morada Colina" },
                    { 64, "Minas Gerais" },
                    { 63, "Minas Brasil" },
                    { 62, "Mercês" },
                    { 88, "Progresso" },
                    { 89, "Prosperidade" },
                    { 90, "Residencial Gramado" },
                    { 91, "Residencial Nosso Lar" },
                    { 117, "Vila Satélite" },
                    { 116, "Vila Povoa" },
                    { 115, "Vila Oswaldo" },
                    { 114, "Vigilato Pereira" },
                    { 113, "Valparaíso" },
                    { 112, "Umuarama" },
                    { 111, "Tubalina" },
                    { 110, "Tocantins" },
                    { 109, "Tibery" },
                    { 108, "Thomas Carmelo" },
                    { 107, "Tancredo Neves" },
                    { 106, "Taiaman" }
                });

            migrationBuilder.InsertData(
                table: "Bairro",
                columns: new[] { "BairroId", "Nome" },
                values: new object[,]
                {
                    { 61, "Matins" },
                    { 105, "Tabajaras" },
                    { 103, "Setor Bom Jesus" },
                    { 102, "Segismundo Pereira" },
                    { 101, "Saraiva" },
                    { 100, "São José" },
                    { 99, "São Jorge" },
                    { 98, "Santa Rosa" },
                    { 97, "Santa Mônica" },
                    { 96, "Santa Maria" },
                    { 95, "Santa Luzia" },
                    { 94, "Rezende Junqueira" },
                    { 93, "Rezende" },
                    { 92, "Residencial Viviane" },
                    { 104, "Shopping Park" },
                    { 59, "Marta Helena" },
                    { 60, "Martins" },
                    { 29, "Higino Guerra" },
                    { 28, "Guarani" },
                    { 27, "Granada" },
                    { 26, "General Osório" },
                    { 25, "Fundinho" },
                    { 24, "Dona Zulmira" },
                    { 23, "Dom Almir" },
                    { 22, "Distrito Industrial" },
                    { 21, "Daniel Fonseca" },
                    { 20, "Custódio Pereira" },
                    { 19, "Conjunto Alvorada" },
                    { 18, "Cidade Jardim" },
                    { 17, "Chs Uirapuru" },
                    { 16, "Chs Tubalina E Quartel" },
                    { 15, "Chaves" },
                    { 14, "Chácaras Tubalina E Quartel" },
                    { 13, "Chácaras Bonanza" },
                    { 12, "Chácara Tubalina" },
                    { 11, "Centro" },
                    { 10, "Cazeca" },
                    { 9, "Carajás" },
                    { 8, "Buritis" },
                    { 7, "Brasil" },
                    { 6, "Bom Jesus" },
                    { 5, "Bela Vista" }
                });

            migrationBuilder.InsertData(
                table: "Bairro",
                columns: new[] { "BairroId", "Nome" },
                values: new object[,]
                {
                    { 4, "Aruanan" },
                    { 58, "Maria Rezende" },
                    { 3, "Alto Umuarama" },
                    { 30, "Industrial" },
                    { 32, "Jardim Botânico" },
                    { 57, "Maravilha" },
                    { 56, "Mansour" },
                    { 55, "Mansões Aeroporto" },
                    { 54, "Luizote Freitas" },
                    { 53, "Luizote de Freitas" },
                    { 52, "Lourdes" },
                    { 51, "Loteamento Integração" },
                    { 50, "Lidice" },
                    { 49, "Laranjeiras" },
                    { 48, "Lagoinha" },
                    { 47, "Jockey Camping" },
                    { 46, "Jardim Umuarama" },
                    { 45, "Jardim Patrícia" },
                    { 44, "Jardim Panorama" },
                    { 43, "Jardim Karaiba" },
                    { 42, "Jardim Ipanema" },
                    { 41, "Jardim Inconfidência" },
                    { 40, "Jardim Holanda" },
                    { 39, "Jardim Finotti" },
                    { 38, "Jardim Europa" },
                    { 37, "Jardim das Palmeiras" },
                    { 36, "Jardim Colina" },
                    { 35, "Jardim Canaã" },
                    { 34, "Jardim Califórnia" },
                    { 33, "Jardim Brasília" },
                    { 31, "Jaraguá" },
                    { 2, "Aeroporto" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Bairro",
                keyColumn: "BairroId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "TurmaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "TurmaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "TurmaId",
                keyValue: 3);
        }
    }
}
