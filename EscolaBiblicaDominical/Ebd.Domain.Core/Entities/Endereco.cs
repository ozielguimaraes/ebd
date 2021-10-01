using Ebd.Domain.Core.Entities.Enumerators;

namespace Ebd.Domain.Core.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public ClassificacaoEndereco Classificacao { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public int BairroId { get; set; }
        public Bairro Bairro { get; set; }
    }
}
