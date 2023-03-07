namespace Ebd.Domain.Core.Entities
{
    public class ResponsavelAluno
    {
        public int PessoaResponsavelId { get; set; }
        public int ResponsavelId { get; set; }
        public Pessoa Responsavel { get; set; }

        public int AlunoId { get; set; }
    }
}
