using Ebd.Application.Responses.Contato;
using Ebd.Application.Responses.Endereco;
using System;
using System.Collections.Generic;

namespace Ebd.Application.Responses.Pessoa
{
    public class PessoaResponse
    {
        public PessoaResponse(int pessoaId, string nome, bool whatsappIgualCelular, DateOnly nascidoEm, IEnumerable<DetalhesEnderecoResponse> enderecos, IEnumerable<DetalhesContatoResponse> contatos)
        {
            PessoaId = pessoaId;
            Nome = nome;
            WhatsappIgualCelular = whatsappIgualCelular;
            NascidoEm = nascidoEm;
            Enderecos = enderecos;
            Contatos = contatos;
        }

        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public bool WhatsappIgualCelular { get; set; }
        public DateOnly NascidoEm { get; set; }

        public IEnumerable<DetalhesEnderecoResponse> Enderecos { get; set; }
        public IEnumerable<DetalhesContatoResponse> Contatos { get; set; }
    }
}
