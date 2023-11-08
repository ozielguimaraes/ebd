using Ebd.Application.Converters;
using Ebd.Application.Requests.Contato;
using Ebd.Application.Requests.Endereco;
using Ebd.Application.Requests.Pessoa;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ebd.Application.Requests.Aluno
{
    public class AdicionarAlunoRequest
    {
        public string Nome { get; set; }
        public bool WhatsappIgualCelular { get; set; }

        [JsonConverter(typeof(DateTimeToDateOnlyConverter))]
        public DateOnly NascidoEm { get; set; }

        public ICollection<EnderecoRequest> Enderecos { get; set; }
        public ICollection<ContatoRequest> Contatos { get; set; }

        public ICollection<ResponsavelAlunoRequest> Responsaveis { get; set; }

        public int TurmaId { get; set; }
    }
}
