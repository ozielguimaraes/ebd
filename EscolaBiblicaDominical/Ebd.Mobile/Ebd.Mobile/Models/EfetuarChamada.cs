using Ebd.Mobile.Services.Responses.Aluno;

namespace Ebd.Mobile.Models
{
    public class EfetuarChamada
    {
        public EfetuarChamada(AlunoResponse aluno)
        {
            Aluno = aluno;
        }

        public bool ChamadaRealizada { get; private set; }
        public AlunoResponse Aluno { get; private set; }

        public void SetChamadaFoiRealizada()
        {
            ChamadaRealizada = true;
        }
    }
}
