using Ebd.Mobile.Services.Requests.Aluno;

namespace Ebd.Mobile.Services.Requests.Contato
{
    public class ContatoRequest
    {
        public ContatoRequest(string valor, TipoContatoRequest tipo)
        {
            Valor = valor;
            Tipo = tipo;
            Classificacao = ClassificacaoContatoRequest.Principal;
        }

        public ContatoRequest(string valor, TipoContatoRequest tipo, ClassificacaoContatoRequest classificacao)
        {
            Valor = valor;
            Tipo = tipo;
            Classificacao = classificacao;
        }

        public int ContatoId { get; set; }
        public string Valor { get; private set; }
        public TipoContatoRequest Tipo { get; private set; }
        public ClassificacaoContatoRequest Classificacao { get; private set; }
    }
}
