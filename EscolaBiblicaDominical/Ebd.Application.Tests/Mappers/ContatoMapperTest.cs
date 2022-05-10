using Ebd.Application.Requests.Contato;
using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Entities.Enumerators;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Ebd.Application.Mappers.Tests
{
    [TestClass]
    public class ContatoMapperTest
    {
        [TestMethod]
        public void FromRequestToEntity()
        {
            var result = ContatoMapper.FromRequestToEntity(new List<ContatoRequest>
            {
                new ContatoRequest
                {
                    ContatoId = 2,
                    Classificacao = ClassificacaoContatoRequest.Principal,
                    Tipo = TipoContatoRequest.Celular,
                    Valor  = "(69) 12345-6789"
                },
                new ContatoRequest
                {
                    ContatoId = 5,
                    Classificacao = ClassificacaoContatoRequest.CasaAvos,
                    Tipo = TipoContatoRequest.Email,
                    Valor  = "(00) 98765-1234"
                }
            });

            Assert.AreEqual(result.Count(), 2);
            result.Should().BeEquivalentTo(new List<Contato>
            {
                new Contato
                {
                    ContatoId = 2,
                    Classificacao = ClassificacaoContato.Principal,
                    Tipo = TipoContato.Celular,
                    Valor = "(69) 12345-6789"
                },
                new Contato
                {
                    ContatoId = 5,
                    Classificacao = ClassificacaoContato.CasaAvos,
                    Tipo = TipoContato.Email,
                    Valor = "(00) 98765-1234"
                }
            });
        }
    }
}
