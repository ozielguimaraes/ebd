namespace Ebd.Application.Responses.Contato
{
    public class DetalhesContatoResponse
    {
        public DetalhesContatoResponse(int contatoId, string valor, TipoContatoResponse tipo, ClassificacaoContatoResponse classificacao)
        {
            ContatoId = contatoId;
            Valor = valor;
            Tipo = tipo;
            Classificacao = classificacao;
        }

        public int ContatoId { get; set; }
        public string Valor { get; set; }
        public TipoContatoResponse Tipo { get; set; }
        public ClassificacaoContatoResponse Classificacao { get; set; }
    }
}
