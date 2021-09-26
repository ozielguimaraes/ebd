using System;
using System.Collections.Generic;

namespace Ebd.Domain.Core.Entities
{
    public class Pessoa
    {
        public int PessoaId { get; private set; }
        public string Nome { get; private set; }
        public bool WhatsappIgualCelular { get; private set; }
        public DateTime NascidoEm { get; private set; }

        public ICollection<Endereco> Enderecos {  get; private set;}
        public ICollection<Contato> Contatos {  get; private set;}
    }
}
