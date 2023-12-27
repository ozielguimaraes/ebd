using Ebd.CrossCutting.Enumerators;

namespace Ebd.Mobile.Services.Requests.Contato
{
    public class ContatoRequest
    {
        public ContatoRequest(string valor, TipoContato tipo)
        {
            Valor = valor;
            Tipo = tipo;
            Classificacao = ClassificacaoContato.Principal;
        }

        public ContatoRequest(string valor, TipoContato tipo, ClassificacaoContato classificacao)
        {
            Valor = valor;
            Tipo = tipo;
            Classificacao = classificacao;
        }

        public int ContatoId { get; set; }
        public string Valor { get; private set; }
        public TipoContato Tipo { get; private set; }
        public ClassificacaoContato Classificacao { get; private set; }
    }
}
