using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Ebd.Mobile.Services.Responses.Aluno;
using Ebd.Mobile.Services.Interfaces;
using System;
using Xamarin.Essentials;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System.Collections.Generic;
using Ebd.Mobile.Services.Implementations;
using Xamarin.Forms;
using Ebd.Mobile.Services.Responses.Turma;

namespace Ebd.Mobile.ViewModels.Aluno
{
    public class ListaAlunoViewModel : BaseViewModel
    {
        private static readonly Lazy<IAlunoService> alunoServiceLazy = new(() => new AlunoService(DependencyService.Get<INetworkService>()));
        private readonly IAlunoService _alunoService = alunoServiceLazy.Value;

        private static readonly Lazy<ITurmaService> turmaServiceLazy = new(() => new TurmaService(DependencyService.Get<INetworkService>()));
        private readonly ITurmaService _turmaService = turmaServiceLazy.Value;
        //private readonly IAlunoService _alunoService;
        //private readonly ITurmaService _turmaService;

        public ListaAlunoViewModel(/*IAlunoService alunoService, ITurmaService turmaService*/)
        {
            Title = "Alunos";
            //_alunoService = alunoService;
            //_turmaService = turmaService;
        }


        //private ObservableCollection<AlunoResponse> alunos = new();
        //public ObservableCollection<AlunoResponse> Alunos
        //{
        //    get => alunos;
        //    set => SetProperty(ref alunos, value);
        //}

        public ObservableCollection<AlunoResponse> Alunos { get; private set; } = new ObservableCollection<AlunoResponse>();
        public ObservableCollection<TurmaResponse> Turmas { get; private set; } = new ObservableCollection<TurmaResponse>();

        private TurmaResponse turmaSelecionada;
        public TurmaResponse TurmaSelecionada
        {
            get => turmaSelecionada;
            set
            {
                var turmaSelecionadaAnteriormente = turmaSelecionada;
                SetProperty(ref turmaSelecionada, value);

                if (!turmaSelecionada.Equals(turmaSelecionadaAnteriormente))
                    CarregarListaAlunosCommand.ExecuteAsync(true).ConfigureAwait(true);
            }
        }

        private readonly AsyncCommand<bool> _carregarListaAlunosCommand;
        public AsyncCommand<bool> CarregarListaAlunosCommand
            => _carregarListaAlunosCommand
            ?? new AsyncCommand<bool>(
                execute: ExecuteCarregarListaAlunosCommand,
                onException: CommandOnException);

        public override async Task Initialize(object args)
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    DialogService.ShowLoading();
                });

                var turmas = await _turmaService.ObterTodasAsync();
                Turmas.Clear();
                foreach (var item in turmas)
                {
                    MainThread.BeginInvokeOnMainThread(() => Turmas.Add(item));
                }

                if (Turmas.Count == 0)
                {
                    await Shell.Current.GoToAsync("..");
                    await DialogService.DisplayAlert("Oops", "Nenhuma turma foi encontrada");
                }
                else if (Turmas.Count == 1)
                {
                    TurmaSelecionada = Turmas[0];
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error to load list of classes", ex);
                DiagnosticService.TrackError(ex);
                await Shell.Current.GoToAsync("..");

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await DialogService.DisplayAlert(ex);
                });
            }
            finally
            {
                MainThread.BeginInvokeOnMainThread(() =>
               {
                   DialogService.HideLoading();
               });

                IsBusy = false;
            }
        }

        private async Task ExecuteCarregarListaAlunosCommand(bool force)
        {
            if (IsBusy && !force) return;
            try
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    DialogService.ShowLoading("Buscando alunos da turma...");
                });
                IsBusy = true;
                var alunos = await _alunoService.ObterPorTurmaIdAsync(TurmaSelecionada.TurmaId);
                Alunos.Clear();
                foreach (var item in alunos)
                {
                    MainThread.BeginInvokeOnMainThread(() => Alunos.Add(item));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error to load list of students", ex, new Dictionary<string, object> { { nameof(force), force } });
                DiagnosticService.TrackError(ex);
                await Shell.Current.GoToAsync("..");
                await DialogService.DisplayAlert(ex);
            }
            finally
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    DialogService.HideLoading();
                });
                IsBusy = false;
            }
        }
    }
}
