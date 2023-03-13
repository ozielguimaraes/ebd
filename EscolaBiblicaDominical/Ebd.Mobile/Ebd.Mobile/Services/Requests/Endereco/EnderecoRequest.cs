using Ebd.CrossCutting.Enumerators;

namespace Ebd.Mobile.Services.Requests.Endereco
{
    public class EnderecoRequest
    {
        public EnderecoRequest(string logradouro, string numero, string cep, int bairroId)
        {
            Logradouro = logradouro;
            Numero = numero;
            Cep = cep;
            BairroId = bairroId;
            Classificacao = ClassificacaoEndereco.Principal;
        }

        public int EnderecoId { get; set; }
        public ClassificacaoEndereco Classificacao { get; set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Cep { get; private set; }
        public int BairroId { get; private set; }
    }
}
