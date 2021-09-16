namespace Ebd.Domain.Core.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Cep { get; private set; }

        public int BairroId { get; private set; }
        public Bairro Bairro { get; private set; }
    }
}
