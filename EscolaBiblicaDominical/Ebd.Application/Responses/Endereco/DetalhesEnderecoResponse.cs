using Ebd.CrossCutting.Enumerators;

namespace Ebd.Application.Responses.Endereco
{
    public class DetalhesEnderecoResponse
    {
        public DetalhesEnderecoResponse(int enderecoId, ClassificacaoEndereco classificacao, string logradouro, string numero, string cep, BairroResponse bairro)
        {
            EnderecoId = enderecoId;
            Classificacao = classificacao;
            Logradouro = logradouro;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
        }

        public int EnderecoId { get; set; }
        public ClassificacaoEndereco Classificacao { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }

        public BairroResponse Bairro { get; set; }
    }
}
