using Ebd.Domain.Core.Entities.Enumerators;

namespace Ebd.Domain.Core.Entities
{
   public class Contato
    {
        public int ContatoId { get; private set; }
        public string Valor { get; private set; }
        public TipoContato Tipo { get; private set; }
        public ClassificacaoContato Classificacao { get; private set; }

        public int PessoaId { get; private set; }
        public Pessoa Pessoa { get; private set; }
    }
}
