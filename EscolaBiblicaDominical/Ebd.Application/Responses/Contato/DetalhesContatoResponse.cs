using Ebd.CrossCutting.Enumerators;

namespace Ebd.Application.Responses.Contato
{
    public class DetalhesContatoResponse
    {
        public DetalhesContatoResponse(int contatoId, string valor, TipoContato tipo, ClassificacaoContato classificacao)
        {
            ContatoId = contatoId;
            Valor = valor;
            Tipo = tipo;
            Classificacao = classificacao;
        }

        public int ContatoId { get; set; }
        public string Valor { get; set; }
        public TipoContato Tipo { get; set; }
        public ClassificacaoContato Classificacao { get; set; }
    }
}
