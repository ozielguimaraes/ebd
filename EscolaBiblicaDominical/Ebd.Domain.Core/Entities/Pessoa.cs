using System;
using System.Collections.Generic;

namespace Ebd.Domain.Core.Entities
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public bool WhatsappIgualCelular { get; set; }
        public DateTime NascidoEm { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }
        public ICollection<Contato> Contatos { get; set; }
    }
}
