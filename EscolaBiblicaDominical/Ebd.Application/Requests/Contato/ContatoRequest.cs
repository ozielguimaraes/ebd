namespace Ebd.Application.Requests.Contato
{
    public class ContatoRequest
    {
        public int ContatoId { get; private set; }
        public string Valor { get; private set; }
        public TipoContatoRequest Tipo { get; private set; }
        public ClassificacaoContatoRequest Classificacao { get; private set; }
    }
}
