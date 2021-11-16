using Ebd.Mobile.Services.Implementations;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Responses.Aluno;
using Ebd.Mobile.Services.Responses.Turma;
using Ebd.Mobile.Views.Chamada;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ebd.Mobile.ViewModels.Chamada
{
    internal class EscolherTurmaViewModel : BaseViewModel
    {
        private static readonly Lazy<IAlunoService> alunoServiceLazy = new(() => new AlunoService(DependencyService.Get<INetworkService>()));
        private readonly IAlunoService _alunoService = alunoServiceLazy.Value;

        private static readonly Lazy<ITurmaService> turmaServiceLazy = new(() => new TurmaService(DependencyService.Get<INetworkService>()));
        private readonly ITurmaService _turmaService = turmaServiceLazy.Value;

        public EscolherTurmaViewModel()
        {
            Title = "Escolher turma";
        }

        private TurmaResponse turmaSelecionada;
        public TurmaResponse TurmaSelecionada
        {
            get => turmaSelecionada;
            set
            {
                var turmaSelecionadaAnteriormente = turmaSelecionada;
                SetProperty(ref turmaSelecionada, value);

                if (turmaSelecionada  is not null && !turmaSelecionada.Equals(turmaSelecionadaAnteriormente))
                    CarregarListaAlunosCommand.ExecuteAsync(true).ConfigureAwait(true);
            }
        }

        //private bool podeIniciarChamada = false;
        //public bool PodeIniciarChamada
        //{
        //    get => podeIniciarChamada;
        //    set => SetProperty(ref podeIniciarChamada, value);
        //}

        public ObservableCollection<TurmaResponse> Turmas { get; private set; } = new ObservableCollection<TurmaResponse>();
        public ObservableCollection<AlunoResponse> Alunos { get; private set; } = new ObservableCollection<AlunoResponse>();

        private readonly AsyncCommand<bool> _carregarListaAlunosCommand;
        public AsyncCommand<bool> CarregarListaAlunosCommand
            => _carregarListaAlunosCommand
            ?? new AsyncCommand<bool>(
                execute: ExecuteCarregarListaAlunosCommand,
                onException: CommandOnException);

        private readonly AsyncCommand _iniciarChamadaCommand;
        public AsyncCommand IniciarChamadaCommand
            => _iniciarChamadaCommand
            ?? new AsyncCommand(
                execute: ExecuteIniciarChamadaCommand,
                onException: CommandOnException);

        public override async Task Initialize(object args)
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    DialogService.ShowLoading("Buscando as turmas...");
                });

                var response = await _turmaService.ObterTodasAsync();

                if (response.HasError)
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        DialogService.HideLoading();
                    });

                    IsBusy = false;
                    await DialogService.DisplayAlert("Oops", response.Exception.Message);
                    return;
                }

                Turmas.Clear();
                foreach (var item in response.Data)
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

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await Shell.Current.GoToAsync("..");
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
                var response = await _alunoService.ObterPorTurmaIdAsync(TurmaSelecionada.TurmaId);
                if (response.HasError)
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        DialogService.HideLoading();
                    });

                    IsBusy = false;
                    await DialogService.DisplayAlert("Oops", response.Exception.Message);
                    return;
                }

                Alunos.Clear();
                foreach (var item in response.Data)
                {
                    MainThread.BeginInvokeOnMainThread(() => Alunos.Add(item));
                }

                //PodeIniciarChamada = Alunos.Any();

                if (!Alunos.Any())
                    await DialogService.DisplayAlert("Oops", "Nenhum aluno encontrado para a turma");
            }
            catch (Exception ex)
            {
                Logger.LogError("Error to load list of students", ex, new Dictionary<string, object> { { nameof(force), force } });
                DiagnosticService.TrackError(ex);
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await Shell.Current.GoToAsync("..");
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

        private async Task ExecuteIniciarChamadaCommand()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                await Shell.Current.GoToAsync($"{nameof(EfetuarChamadaPage)}?LicaoId=8,Content={JsonSerializer.Serialize(TurmaSelecionada)}&AlunosTurma={JsonSerializer.Serialize(Alunos)}");
            }
            catch (Exception ex)
            {
                Logger.LogError("Error to start class presence", ex);
                DiagnosticService.TrackError(ex);
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
    }
}
