using Ebd.Mobile.ViewModels;

namespace Ebd.Mobile.UnitTests.ViewModels
{
    public class HomeViewModelTest
    {
        [Fact]
        public void GoToAlunoPageCommandIsNotNull()
        {
            HomeViewModel viewModel = new();
            Assert.NotNull(viewModel.GoToAlunoPageCommand);
        }
    }
}