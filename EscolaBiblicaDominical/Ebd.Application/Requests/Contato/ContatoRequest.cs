namespace Ebd.Application.Requests.Contato
{
    public class ContatoRequest
    {
        public int ContatoId { get; set; }
        public string Valor { get; set; }
        public TipoContatoRequest Tipo { get; set; }
        public ClassificacaoContatoRequest Classificacao { get; set; }
    }
}
