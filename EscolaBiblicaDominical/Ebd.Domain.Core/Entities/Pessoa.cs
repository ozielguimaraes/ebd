using System;

namespace Ebd.Domain.Core.Entities
{
    public class Pessoa
    {
        public int PessoaId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Celular { get; private set; }
        public bool WhatsappIgualCelular { get; private set; }
        public string Whatsapp { get; private set; }
        public DateTime NascidoEm { get; private set; }
    }
}
