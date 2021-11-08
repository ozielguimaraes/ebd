using Ebd.Mobile.Services.Interfaces;

namespace Ebd.Mobile.ViewModels.Chamada
{
    internal class EfetuarChamadaViewModel : BaseViewModel
    {
        private string aluno;

        public EfetuarChamadaViewModel()
        {
        }

        public string Aluno
        {
            get => aluno;
            set => SetProperty(ref aluno, value);
        }
    }
}
