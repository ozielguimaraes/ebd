using Ebd.Application.Requests.Contato;
using Ebd.Application.Requests.Endereco;
using System;
using System.Collections.Generic;

namespace Ebd.Application.Requests.Aluno
{
    public class ResponsavelRequest
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public bool WhatsappIgualCelular { get; set; }
        public DateTime NascidoEm { get; set; }

        public ICollection<EnderecoRequest> Enderecos { get; set; }
        public ICollection<ContatoRequest> Contatos { get; set; }
    }
}
