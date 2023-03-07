﻿namespace Ebd.Mobile.Services.Requests.Aluno
{
    public class ResponsavelAlunoRequest
    {
        public ResponsavelAlunoRequest(int pessoaResponsavelId, int responsavelId, PessoaRequest responsavel, int alunoId)
        {
            PessoaResponsavelId = pessoaResponsavelId;
            ResponsavelId = responsavelId;
            Responsavel = responsavel;
            AlunoId = alunoId;
        }

        public int PessoaResponsavelId { get; private set; }
        public int ResponsavelId { get; private set; }
        public PessoaRequest Responsavel { get; private set; }

        public int AlunoId { get; private set; }
    }
}
