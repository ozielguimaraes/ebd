namespace Ebd.Application.Requests.Endereco
{
    public class EnderecoRequest
    {
        public int EnderecoId { get; set; }
        public ClassificacaoEnderecoRequest Classificacao { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public int BairroId { get; set; }
    }
}
