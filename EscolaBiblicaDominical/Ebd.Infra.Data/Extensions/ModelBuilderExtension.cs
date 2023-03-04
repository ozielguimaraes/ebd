using Ebd.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ebd.Infra.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void InserirRegistrosPadrao(this ModelBuilder builder)
        {
            builder.InserirBairros();
            builder.InserirTurmas();
            builder.InserirAvaliacoes();
        }

        private static void InserirAvaliacoes(this ModelBuilder builder)
        {
            var avaliacoes = new List<Avaliacao>
            {
                new Avaliacao(avaliacaoId: 1, nome: "Presença", nota: 2),
                new Avaliacao(avaliacaoId: 2, nome: "Visita", nota: 3),
                new Avaliacao(avaliacaoId: 3, nome: "Lição", nota: 2),
                new Avaliacao(avaliacaoId: 4, nome: "Bíblia", nota: 3),
                new Avaliacao(avaliacaoId: 5, nome: "Visita", nota: 1)
            };
            builder.Entity<Avaliacao>().HasData(avaliacoes);
        }

        private static void InserirTurmas(this ModelBuilder builder)
        {
            var turmas = new List<Turma>
            {
                new Turma(turmaId: 1, nome: "Mensageiros da Fé", idadeMinima: 11,idadeMaxima: 12),
                new Turma(turmaId: 2, nome: "Adolescentes Vencedores", idadeMinima: 13,idadeMaxima: 14),
                new Turma(turmaId: 3, nome: "Campeões da Fé", idadeMinima: 15,idadeMaxima: 17)
            };

            builder.Entity<Turma>().HasData(turmas);
        }

        private static void InserirBairros(this ModelBuilder builder)
        {
            var bairros = new List<Bairro>
            {
                new Bairro { BairroId = 1, Nome = "Aclimação" },
                new Bairro { BairroId = 2, Nome = "Aeroporto" },
                new Bairro { BairroId = 3, Nome = "Alto Umuarama" },
                new Bairro { BairroId = 4, Nome = "Aruanan" },
                new Bairro { BairroId = 5, Nome = "Bela Vista" },
                new Bairro { BairroId = 6, Nome = "Bom Jesus" },
                new Bairro { BairroId = 7, Nome = "Brasil" },
                new Bairro { BairroId = 8, Nome = "Buritis" },
                new Bairro { BairroId = 9, Nome = "Carajás" },
                new Bairro { BairroId = 10, Nome = "Cazeca" },
                new Bairro { BairroId = 11, Nome = "Centro" },
                new Bairro { BairroId = 12, Nome = "Chácara Tubalina" },
                new Bairro { BairroId = 13, Nome = "Chácaras Bonanza" },
                new Bairro { BairroId = 14, Nome = "Chácaras Tubalina E Quartel" },
                new Bairro { BairroId = 15, Nome = "Chaves" },
                new Bairro { BairroId = 16, Nome = "Chs Tubalina E Quartel" },
                new Bairro { BairroId = 17, Nome = "Chs Uirapuru" },
                new Bairro { BairroId = 18, Nome = "Cidade Jardim" },
                new Bairro { BairroId = 19, Nome = "Conjunto Alvorada" },
                new Bairro { BairroId = 20, Nome = "Custódio Pereira" },
                new Bairro { BairroId = 21, Nome = "Daniel Fonseca" },
                new Bairro { BairroId = 22, Nome = "Distrito Industrial" },
                new Bairro { BairroId = 23, Nome = "Dom Almir" },
                new Bairro { BairroId = 24, Nome = "Dona Zulmira" },
                new Bairro { BairroId = 25, Nome = "Fundinho" },
                new Bairro { BairroId = 26, Nome = "General Osório" },
                new Bairro { BairroId = 27, Nome = "Granada" },
                new Bairro { BairroId = 28, Nome = "Guarani" },
                new Bairro { BairroId = 29, Nome = "Higino Guerra" },
                new Bairro { BairroId = 30, Nome = "Industrial" },
                new Bairro { BairroId = 31, Nome = "Jaraguá" },
                new Bairro { BairroId = 32, Nome = "Jardim Botânico" },
                new Bairro { BairroId = 33, Nome = "Jardim Brasília" },
                new Bairro { BairroId = 34, Nome = "Jardim Califórnia" },
                new Bairro { BairroId = 35, Nome = "Jardim Canaã" },
                new Bairro { BairroId = 36, Nome = "Jardim Colina" },
                new Bairro { BairroId = 37, Nome = "Jardim das Palmeiras" },
                new Bairro { BairroId = 38, Nome = "Jardim Europa" },
                new Bairro { BairroId = 39, Nome = "Jardim Finotti" },
                new Bairro { BairroId = 40, Nome = "Jardim Holanda" },
                new Bairro { BairroId = 41, Nome = "Jardim Inconfidência" },
                new Bairro { BairroId = 42, Nome = "Jardim Ipanema" },
                new Bairro { BairroId = 43, Nome = "Jardim Karaiba" },
                new Bairro { BairroId = 44, Nome = "Jardim Panorama" },
                new Bairro { BairroId = 45, Nome = "Jardim Patrícia" },
                new Bairro { BairroId = 46, Nome = "Jardim Umuarama" },
                new Bairro { BairroId = 47, Nome = "Jockey Camping" },
                new Bairro { BairroId = 48, Nome = "Lagoinha" },
                new Bairro { BairroId = 49, Nome = "Laranjeiras" },
                new Bairro { BairroId = 50, Nome = "Lidice" },
                new Bairro { BairroId = 51, Nome = "Loteamento Integração" },
                new Bairro { BairroId = 52, Nome = "Lourdes" },
                new Bairro { BairroId = 53, Nome = "Luizote de Freitas" },
                new Bairro { BairroId = 54, Nome = "Luizote Freitas" },
                new Bairro { BairroId = 55, Nome = "Mansões Aeroporto" },
                new Bairro { BairroId = 56, Nome = "Mansour" },
                new Bairro { BairroId = 57, Nome = "Maravilha" },
                new Bairro { BairroId = 58, Nome = "Maria Rezende" },
                new Bairro { BairroId = 59, Nome = "Marta Helena" },
                new Bairro { BairroId = 60, Nome = "Martins" },
                new Bairro { BairroId = 61, Nome = "Matins" },
                new Bairro { BairroId = 62, Nome = "Mercês" },
                new Bairro { BairroId = 63, Nome = "Minas Brasil" },
                new Bairro { BairroId = 64, Nome = "Minas Gerais" },
                new Bairro { BairroId = 65, Nome = "Morada Colina" },
                new Bairro { BairroId = 66, Nome = "Morada da Colina" },
                new Bairro { BairroId = 67, Nome = "Morada dos Pássaros" },
                new Bairro { BairroId = 68, Nome = "Morada Nova" },
                new Bairro { BairroId = 69, Nome = "Morada Nova Ii" },
                new Bairro { BairroId = 70, Nome = "Morumbi" },
                new Bairro { BairroId = 71, Nome = "Nossa Senhora Aparecida" },
                new Bairro { BairroId = 72, Nome = "Nossa Senhora das Graças" },
                new Bairro { BairroId = 73, Nome = "Nossa Sra Graças" },
                new Bairro { BairroId = 74, Nome = "Nosso Recanto" },
                new Bairro { BairroId = 76, Nome = "Nova Uberlândia" },
                new Bairro { BairroId = 77, Nome = "Novo Mundo" },
                new Bairro { BairroId = 78, Nome = "Osvaldo Resende" },
                new Bairro { BairroId = 79, Nome = "Osvaldo Rezende" },
                new Bairro { BairroId = 80, Nome = "Pacaembu" },
                new Bairro { BairroId = 81, Nome = "Pampulha" },
                new Bairro { BairroId = 82, Nome = "Panorama" },
                new Bairro { BairroId = 83, Nome = "Parque Américas" },
                new Bairro { BairroId = 84, Nome = "Parque das Américas" },
                new Bairro { BairroId = 85, Nome = "Patrimônio" },
                new Bairro { BairroId = 86, Nome = "Planalto" },
                new Bairro { BairroId = 87, Nome = "Presidente Roosevelt" },
                new Bairro { BairroId = 88, Nome = "Progresso" },
                new Bairro { BairroId = 89, Nome = "Prosperidade" },
                new Bairro { BairroId = 90, Nome = "Residencial Gramado" },
                new Bairro { BairroId = 91, Nome = "Residencial Nosso Lar" },
                new Bairro { BairroId = 92, Nome = "Residencial Viviane" },
                new Bairro { BairroId = 93, Nome = "Rezende" },
                new Bairro { BairroId = 94, Nome = "Rezende Junqueira" },
                new Bairro { BairroId = 95, Nome = "Santa Luzia" },
                new Bairro { BairroId = 96, Nome = "Santa Maria" },
                new Bairro { BairroId = 97, Nome = "Santa Mônica" },
                new Bairro { BairroId = 98, Nome = "Santa Rosa" },
                new Bairro { BairroId = 99, Nome = "São Jorge" },
                new Bairro { BairroId = 100, Nome = "São José" },
                new Bairro { BairroId = 101, Nome = "Saraiva" },
                new Bairro { BairroId = 102, Nome = "Segismundo Pereira" },
                new Bairro { BairroId = 103, Nome = "Setor Bom Jesus" },
                new Bairro { BairroId = 104, Nome = "Shopping Park" },
                new Bairro { BairroId = 105, Nome = "Tabajaras" },
                new Bairro { BairroId = 106, Nome = "Taiaman" },
                new Bairro { BairroId = 107, Nome = "Tancredo Neves" },
                new Bairro { BairroId = 108, Nome = "Thomas Carmelo" },
                new Bairro { BairroId = 109, Nome = "Tibery" },
                new Bairro { BairroId = 110, Nome = "Tocantins" },
                new Bairro { BairroId = 111, Nome = "Tubalina" },
                new Bairro { BairroId = 112, Nome = "Umuarama" },
                new Bairro { BairroId = 113, Nome = "Valparaíso" },
                new Bairro { BairroId = 114, Nome = "Vigilato Pereira" },
                new Bairro { BairroId = 115, Nome = "Vila Oswaldo" },
                new Bairro { BairroId = 116, Nome = "Vila Povoa" },
                new Bairro { BairroId = 117, Nome = "Vila Satélite" }
            };
            builder.Entity<Bairro>().HasData(bairros);
        }
    }
}
