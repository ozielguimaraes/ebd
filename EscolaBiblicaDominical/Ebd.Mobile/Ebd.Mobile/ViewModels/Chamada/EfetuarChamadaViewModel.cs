using Ebd.Mobile.Models;
using Ebd.Mobile.Services.Implementations;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Requests.Chamada;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Aluno;
using Ebd.Mobile.Services.Responses.Avaliacao;
using Ebd.Mobile.Services.Responses.Turma;
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
    [QueryProperty(nameof(LicaoId), nameof(LicaoId))]
    [QueryProperty(nameof(Turma), nameof(Turma))]
    [QueryProperty(nameof(AlunosTurma), nameof(AlunosTurma))]
    internal class EfetuarChamadaViewModel : BaseViewModel
    {
        private const int IdAvaliacaoPresenca = 1;
        private static readonly Lazy<IAlunoService> alunoServiceLazy = new(() => new AlunoService(DependencyService.Get<INetworkService>()));
        private readonly IAlunoService _alunoService = alunoServiceLazy.Value;

        private static readonly Lazy<ITurmaService> turmaServiceLazy = new(() => new TurmaService(DependencyService.Get<INetworkService>()));
        private readonly ITurmaService _turmaService = turmaServiceLazy.Value;

        private static readonly Lazy<IAvaliacaoService> avaliacaoServiceLazy = new(() => new AvaliacaoService(DependencyService.Get<INetworkService>()));
        private readonly IAvaliacaoService _avaliacaoService = avaliacaoServiceLazy.Value;

        private static readonly Lazy<IChamadaService> chamadaServiceLazy = new(() => new ChamadaService(DependencyService.Get<INetworkService>()));
        private readonly IChamadaService _chamadaService = chamadaServiceLazy.Value;

        public EfetuarChamadaViewModel()
        {
            Title = "Efetuar chamada";
        }

        public int LicaoSelecionadaId { get; set; }
        public List<EfetuarChamada> AlunosParaEfetuarChamada { get; private set; } = new List<EfetuarChamada>();
        public ObservableCollection<RealizarAvaliacao> Avaliacoes { get; private set; } = new ObservableCollection<RealizarAvaliacao>();

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

        private string licaoId;
        public string LicaoId
        {
            get => licaoId;
            set
            {
                var content = Uri.UnescapeDataString(value);
                SetProperty(ref licaoId, value);
                SetLicaoId(content);
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
                SetAlunos(content);
            }
        }

        private bool estaPresente;
        public bool EstaPresente
        {
            get => estaPresente;
            set => SetProperty(ref estaPresente, value);
        }

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

        private EfetuarChamada alunoParaEfetuarChamada;
        public EfetuarChamada AlunoParaEfetuarChamada
        {
            get => alunoParaEfetuarChamada;
            set => SetProperty(ref alunoParaEfetuarChamada, value);
        }

        private readonly AsyncCommand<bool> _carregarListaAlunosCommand;
        public AsyncCommand<bool> CarregarListaAlunosCommand
            => _carregarListaAlunosCommand
            ?? new AsyncCommand<bool>(
                execute: ExecuteCarregarListaAlunosCommand,
                onException: CommandOnException);

        private readonly AsyncCommand _proximoAlunoCommand;
        public AsyncCommand ProximoAlunoCommand
            => _proximoAlunoCommand
            ?? new AsyncCommand(
                execute: ExecuteProximoAlunoCommand,
                onException: CommandOnException);

        public override async Task Initialize(object args)
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    DialogService.ShowLoading("Buscando as avaliações...");
                });

                var response = await _avaliacaoService.ObterTodasAsync();

                if (response.HasError)
                {
                    HideLoading();
                    IsBusy = false;
                    await DialogService.DisplayAlert("Oops", response.Exception.Message);
                    return;
                }

                Avaliacoes.Clear();
                foreach (var item in response.Data.Where(x => x.AvaliacaoId != IdAvaliacaoPresenca))
                {
                    MainThread.BeginInvokeOnMainThread(() => Avaliacoes.Add(new RealizarAvaliacao(item)));
                }
                if (Avaliacoes.Any())
                    SetAlunoParaEfetuarChamada();
                else
                {
                    await Shell.Current.GoToAsync("..");
                    await DialogService.DisplayAlert("Oops", "Não é possível iniciar a chamada\n.Não foi encontrado nenhuma avaliação.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error to load avaliations", ex);
                DiagnosticService.TrackError(ex);

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await Shell.Current.GoToAsync("..");
                    await DialogService.DisplayAlert(ex);
                });
            }
            finally
            {
                HideLoading();
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
                    HideLoading();

                    IsBusy = false;
                    await DialogService.DisplayAlert("Oops", response.Exception.Message);
                    return;
                }

                AlunosParaEfetuarChamada.Clear();
                foreach (var item in response.Data)
                {
                    MainThread.BeginInvokeOnMainThread(() => AlunosParaEfetuarChamada.Add(new EfetuarChamada(item)));
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
                HideLoading();
                IsBusy = false;
            }
        }

        private async Task ExecuteProximoAlunoCommand()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    DialogService.ShowLoading("Salvando...");
                });
                var efetuarChamadaResponse = await EfetuarChamadaAsync();
                if (efetuarChamadaResponse.HasError)
                {
                    HideLoading();
                    IsBusy = false;
                    await DialogService.DisplayAlert("Oops", efetuarChamadaResponse.Exception.Message);
                    return;
                }

                SetChamadaRealizada();
                SetAlunoParaEfetuarChamada();

                if (NaoPossuiAlgumAlunoParaEfetuarChamada())
                {
                    HideLoading();
                    IsBusy = false;
                    await DialogService.DisplayAlert("Hehe", "Chamada realizada com sucesso.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error to load list of students", ex);
                DiagnosticService.TrackError(ex);
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await Shell.Current.GoToAsync("..");
                    await DialogService.DisplayAlert(ex);
                });
            }
            finally
            {
                HideLoading();
                IsBusy = false;
            }
        }

        private void SetChamadaRealizada()
        {
            var alunoAtual = AlunosParaEfetuarChamada.First(f => f.Aluno.AlunoId == AlunoParaEfetuarChamada.Aluno.AlunoId);
            alunoAtual.SetChamadaFoiRealizada();
            AlunosParaEfetuarChamada.Remove(alunoAtual);
            AlunosParaEfetuarChamada.Add(alunoAtual);
        }

        private async Task<EmptyResponse> EfetuarChamadaAsync()
        {
            var request = new ChamadaRequest(
                alunoId: AlunoParaEfetuarChamada.Aluno.AlunoId,
                licaoId: LicaoSelecionadaId,
                estavaPresente: EstaPresente,
                avaliacoes: ObterIdAvaliacoesRealizadas()
                );
            return await _chamadaService.EfetuarChamadaAsync(request);
        }

        private IEnumerable<int> ObterIdAvaliacoesRealizadas()
            => EstaPresente ? Avaliacoes.Where(x => x.FoiRealizada).Select(x => x.AvaliacaoId) : null;

        private void SetLicaoId(string content)
        {
            LicaoSelecionadaId = int.Parse(content);
        }

        private void SetTurmaSelecionada(string content)
        {
            TurmaSelecionada = JsonSerializer.Deserialize<TurmaResponse>(content);
        }

        private void SetAlunos(string content)
        {
            AlunosParaEfetuarChamada.AddRange(JsonSerializer.Deserialize<List<AlunoResponse>>(content).Select(x => new EfetuarChamada(x)));
        }

        private bool NaoPossuiAlgumAlunoParaEfetuarChamada()
            => AlunoParaEfetuarChamada is null;

        private void SetAlunoParaEfetuarChamada()
        {
            AlunoParaEfetuarChamada = AlunosParaEfetuarChamada.FirstOrDefault(x => !x.ChamadaRealizada);
        }
    }
}
