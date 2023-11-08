using Ebd.Application.Converters;
using Ebd.Application.Requests.Contato;
using Ebd.Application.Requests.Endereco;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ebd.Application.Requests.Pessoa
{
    public class PessoaRequest
    {
        public string Nome { get; set; }
        public bool WhatsappIgualCelular { get; set; }

        [JsonConverter(typeof(DateTimeToDateOnlyConverter))]
        public DateOnly NascidoEm { get; set; }

        public ICollection<EnderecoRequest> Enderecos { get; set; }
        public ICollection<ContatoRequest> Contatos { get; set; }
    }
}
