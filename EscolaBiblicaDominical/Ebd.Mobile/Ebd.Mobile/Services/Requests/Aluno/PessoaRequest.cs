using Ebd.Mobile.Services.Requests.Contato;
using Ebd.Mobile.Services.Requests.Endereco;
using System;
using System.Collections.Generic;

namespace Ebd.Mobile.Services.Requests.Aluno
{
    public class PessoaRequest
    {
        public PessoaRequest(string nome, ContatoRequest contato)
        {
            Nome = nome;
            Contatos = new List<ContatoRequest> { contato };
            NascidoEm = DateTime.Now.AddYears(-30);
        }

        public string Nome { get; set; }
        public bool WhatsappIgualCelular { get; set; }
        public DateTime NascidoEm { get; set; }

        public ICollection<EnderecoRequest> Enderecos { get; set; }
        public ICollection<ContatoRequest> Contatos { get; set; }
    }
}
