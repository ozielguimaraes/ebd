using Ebd.CrossCutting.Enumerators;

namespace Ebd.Application.Requests.Contato
{
    public class ContatoRequest
    {
        public int ContatoId { get; set; }
        public string Valor { get; set; }
        public TipoContato Tipo { get; set; }
        public ClassificacaoContato Classificacao { get; set; }
    }
}
