﻿using Ebd.Application.Responses.Pessoa;
using Ebd.CrossCutting.Enumerators;

namespace Ebd.Application.Responses.Aluno
{
    public class ResponsavelAlunoResponse
    {
        public ResponsavelAlunoResponse(int pessoaResponsavelId, int responsavelId, PessoaResponse responsavel, int alunoId)
        {
            PessoaResponsavelId = pessoaResponsavelId;
            ResponsavelId = responsavelId;
            Responsavel = responsavel;
            AlunoId = alunoId;
        }

        public int PessoaResponsavelId { get; set; }
        public int ResponsavelId { get; set; }
        public PessoaResponse Responsavel { get; set; }
        public TipoResponsavel TipoResponsavel { get; set; }

        public int AlunoId { get; set; }
    }
}