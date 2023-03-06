using Ebd.Mobile.Constants;
using Ebd.Mobile.Services.Implementations;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Responses.Aluno;
using Ebd.Mobile.Services.Responses.Turma;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ebd.Mobile.ViewModels.Aluno
{
    [QueryProperty(nameof(Turma), nameof(Turma))]
    [QueryProperty(nameof(Alunos), nameof(Alunos))]
    public class ListaAlunoViewModel : BaseViewModel
    {
        private static readonly Lazy<IAlunoService> alunoServiceLazy = new(() => new AlunoService(DependencyService.Get<INetworkService>()));
        private readonly IAlunoService _alunoService = alunoServiceLazy.Value;

        private static readonly Lazy<ITurmaService> turmaServiceLazy = new(() => new TurmaService(DependencyService.Get<INetworkService>()));
        private readonly ITurmaService _turmaService = turmaServiceLazy.Value;

        public ListaAlunoViewModel()
        {
            Title = "Alunos";
        }

        public ObservableRangeCollection<AlunoResponse> Alunos { get; private set; } = new ObservableRangeCollection<AlunoResponse>();
        public ObservableRangeCollection<TurmaResponse> Turmas { get; private set; } = new ObservableRangeCollection<TurmaResponse>();

        private string turma;
        public string Turma
        {
            get => turma;
            set
            {
                var content = Uri.UnescapeDataString(value ?? string.Empty);
                SetProperty(ref turma, value);
                SetTurmaSelecionada(content);
            }
        }

        private string alunosTurma;
        public string AlunosTurma
        {
            get => alunosTurma;
            set
            {
                var content = Uri.UnescapeDataString(value ?? string.Empty);
                SetProperty(ref alunosTurma, value);
                SetAlunosTurma(content);
            }
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
                    MainThread.BeginInvokeOnMainThread(() => CarregarListaAlunosCommand.ExecuteAsync(true).ConfigureAwait(true)); ;
            }
        }

        private AsyncCommand<bool> _carregarListaAlunosCommand;
        public AsyncCommand<bool> CarregarListaAlunosCommand
            => _carregarListaAlunosCommand
            ??= new AsyncCommand<bool>(
                execute: ExecuteCarregarListaAlunosCommand,
                onException: CommandOnException);

        private AsyncCommand _newStudentCommand;
        public AsyncCommand NewStudentCommand
                => _newStudentCommand
                ??= new AsyncCommand(
                    execute: NewStudentCommandExecute,
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

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Turmas.Clear();
                    Turmas.AddRange(response.Data);
                });

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

        private async Task NewStudentCommandExecute()
        {
            if (IsBusy) return;

            await Shell.Current.GoToAsync($"{PageConstant.Aluno.Novo}?Turma={(TurmaSelecionada is null ? null : JsonSerializer.Serialize(TurmaSelecionada))}");
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

        private void SetTurmaSelecionada(string content)
        {
            TurmaSelecionada = JsonSerializer.Deserialize<TurmaResponse>(content);
        }

        private void SetAlunosTurma(string content)
        {
            Alunos.Clear();
            Alunos.AddRange(JsonSerializer.Deserialize<IEnumerable<AlunoResponse>>(content));
        }
    }
}
