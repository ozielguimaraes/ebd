using Ebd.Mobile.Extensions;
using Ebd.Mobile.Services.Implementations;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Aluno;
using Ebd.Mobile.Services.Responses.Turma;
using Ebd.Mobile.Views.Chamada;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
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

        private static readonly Lazy<IRevistaService> revistaServiceLazy = new(() => new RevistaService(DependencyService.Get<INetworkService>()));
        private readonly IRevistaService _revistaService = revistaServiceLazy.Value;

        private static readonly Lazy<ILicaoService> licaoServiceLazy = new(() => new LicaoService(DependencyService.Get<INetworkService>()));
        private readonly ILicaoService _licaoService = revistaServiceLazy.Value;

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

                if (turmaSelecionada is not null && !turmaSelecionada.Equals(turmaSelecionadaAnteriormente))
                    CarregarListaAlunosCommand.ExecuteAsync(true).ConfigureAwait(true);
            }
        }

        private int alunosMatriculados;
        public int AlunosMatriculados
        {
            get => alunosMatriculados;
            set => SetProperty(ref alunosMatriculados, value);
        }

        //private bool podeIniciarChamada = false;
        //public bool PodeIniciarChamada
        //{
        //    get => podeIniciarChamada;
        //    set => SetProperty(ref podeIniciarChamada, value);
        //}

        public ObservableRangeCollection<TurmaResponse> Turmas { get; private set; } = new ObservableRangeCollection<TurmaResponse>();
        public ObservableRangeCollection<AlunoResponse> Alunos { get; private set; } = new ObservableRangeCollection<AlunoResponse>();

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
                MainThread.BeginInvokeOnMainThread(() => Turmas.AddRange(response.Data));

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
                AtualizarAlunos(response);

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

        private void AtualizarAlunos(BaseResponse<IEnumerable<AlunoResponse>> response)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Alunos.AddRange(response.Data);
                AlunosMatriculados = Alunos.Count();
            });
        }

        private async Task ExecuteIniciarChamadaCommand()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    DialogService.ShowLoading("Buscando informações da revista...");
                });

                var revistaResponse = await _revistaService.ObterPorPeriodoAsync(DateTime.Now.Year, DateTimeExtension.ObterTrimestreAtual());

                if (revistaResponse.HasError)
                {
                    HideLoading();
                    IsBusy = false;
                    await DialogService.DisplayAlert("Oops", revistaResponse.Exception.Message);
                    return;
                }
                revistaResponse.Data.RevistaId


                var licaoId = 1;//TODO Get from service..
                await Shell.Current.GoToAsync($"{nameof(EfetuarChamadaPage)}?Licao={licaoId}&Content={JsonSerializer.Serialize(TurmaSelecionada)}&AlunosTurma={JsonSerializer.Serialize(Alunos)}");
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
