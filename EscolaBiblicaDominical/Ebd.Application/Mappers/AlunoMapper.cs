using Ebd.Application.Requests.Aluno;
using Ebd.Domain.Core.Entities;
using System.Linq;

namespace Ebd.Application.Mappers
{
    public class AlunoMapper
    {
        public static Aluno FromRequestToEntity(AdicionarAlunoRequest request)
        {
            return new Aluno
            {
                Pessoa = new Pessoa
                {
                    Nome = request.Nome,
                    NascidoEm = request.NascidoEm,
                    WhatsappIgualCelular = request.WhatsappIgualCelular,
                    Contatos = ContatoMapper.FromRequestToEntity(request.Contatos).ToList(),
                    Enderecos = EnderecoMapper.FromRequestToEntity(request.Enderecos).ToList()
                }
            };
        }
    }
}
