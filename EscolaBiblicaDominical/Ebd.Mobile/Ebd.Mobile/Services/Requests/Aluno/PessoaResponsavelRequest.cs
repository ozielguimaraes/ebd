using Ebd.CrossCutting.Enumerators;

namespace Ebd.Mobile.Services.Requests.Aluno
{
    public class PessoaResponsavelRequest
    {
        public PessoaResponsavelRequest(int pessoaResponsavelId, int responsavelId, PessoaRequest responsavel, int alunoId, TipoResponsavel tipoResponsavel)
        {
            PessoaResponsavelId = pessoaResponsavelId;
            PessoaId = responsavelId;
            Pessoa = responsavel;
            AlunoId = alunoId;
            TipoResponsavel = tipoResponsavel;
        }

        public int PessoaResponsavelId { get; private set; }
        public int PessoaId { get; private set; }
        public PessoaRequest Pessoa { get; private set; }
        public TipoResponsavel TipoResponsavel { get; private set; }

        public int AlunoId { get; private set; }
    }
}
