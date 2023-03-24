﻿using Ebd.CrossCutting.Enumerators;

namespace Ebd.Application.Requests.Pessoa
{
    public class ResponsavelAlunoRequest
    {
        public int PessoaResponsavelId { get; set; }
        public int PessoaId { get; set; }
        public PessoaRequest Pessoa { get; set; }
        public TipoResponsavel TipoResponsavel { get; set; }

        public int AlunoId { get; set; }
    }
}