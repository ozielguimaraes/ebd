namespace Ebd.Mobile.ViewModels.Chamada
{
    internal class EfetuarChamadaViewModel : BaseViewModel
    {
        private string aluno;
        public string Aluno
        {
            get => aluno;
            set => SetProperty(ref aluno, value);
        }
    }
}
