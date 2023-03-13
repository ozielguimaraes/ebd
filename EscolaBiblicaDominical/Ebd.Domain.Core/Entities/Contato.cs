using Ebd.CrossCutting.Enumerators;

namespace Ebd.Domain.Core.Entities
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string Valor { get; set; }
        public TipoContato Tipo { get; set; }
        public ClassificacaoContato Classificacao { get; set; }

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
