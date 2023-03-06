using Ebd.Mobile.Services.Requests.Contato;
using Ebd.Mobile.Services.Requests.Endereco;
using System;
using System.Collections.Generic;

namespace Ebd.Mobile.Services.Requests.Aluno
{
    public class AlterarAlunoRequest
    {
        public int? AlunoId { get; set; }
        public int TurmaId { get; set; }
        //public string Celular { get; set; }
        //public string Email { get; set; }
        //public string NomeMae { get; set; }
        //public string CelularMae { get; set; }
        //public string NomePai { get; set; }
        //public string CelularPai { get; set; }
        //public string Logradouro { get; set; }
        //public string Numero { get; set; }
        //public string Bairro { get; set; }
        //public string Complemento { get; set; }


        public string Nome { get; set; }
        public bool WhatsappIgualCelular { get; set; } = true;
        public DateTime NascidoEm { get; set; }

        public ICollection<NovoEnderecoRequest> Enderecos { get; set; }
        public ICollection<NovoContatoRequest> Contatos { get; set; }

        //public PessoaRequest Responsavel { get; set; }
    }
}
