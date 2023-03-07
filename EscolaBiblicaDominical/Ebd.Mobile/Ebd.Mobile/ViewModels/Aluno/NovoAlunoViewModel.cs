using Ebd.Mobile.Extensions;
using Ebd.Mobile.Services.Implementations;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Requests.Contato;
using Ebd.Mobile.Services.Requests.Endereco;
using Ebd.Mobile.Services.Responses.Turma;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ebd.Mobile.ViewModels.Aluno
{
    [QueryProperty(nameof(Turma), nameof(Turma))]
    public class NovoAlunoViewModel : BaseViewModel
    {
        private static readonly INetworkService _networkService = DependencyService.Get<INetworkService>();

        private static readonly Lazy<IAlunoService> alunoServiceLazy = new(() => new AlunoService(_networkService));
        private readonly IAlunoService _alunoService = alunoServiceLazy.Value;

        private static readonly Lazy<ICepService> cepServiceLazy = new(() => new CepService(_networkService));
        private readonly ICepService _cepService = cepServiceLazy.Value;

        private static readonly Lazy<ITurmaService> turmaServiceLazy = new(() => new TurmaService(_networkService));
        private readonly ITurmaService _turmaService = turmaServiceLazy.Value;

        public NovoAlunoViewModel()
        {
            Title = "Adicionar aluno";
        }

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

        private TurmaResponse turmaSelecionada;
        public TurmaResponse TurmaSelecionada
        {
            get => turmaSelecionada;
            set
            {
                var turmaSelecionadaAnteriormente = turmaSelecionada;
                SetProperty(ref turmaSelecionada, value);

                if (turmaSelecionada is not null && turmaSelecionada.Equals(turmaSelecionadaAnteriormente).Not())
                {
                    Debug.WriteLine("test");
                    //MainThread.BeginInvokeOnMainThread(() => CarregarListaAlunosCommand.ExecuteAsync(true).ConfigureAwait(true)); ;
                }
            }
        }

        public ObservableRangeCollection<TurmaResponse> Turmas { get; private set; } = new ObservableRangeCollection<TurmaResponse>();

        private AsyncCommand _salvarCommand;
        public AsyncCommand SalvarCommand
                => _salvarCommand
                ??= new AsyncCommand(
                    execute: SalvarCommandExecute,
                    canExecute: CanExecute,
                    onException: CommandOnException);

        private ICommand _cepCompletedCommand;
        public ICommand CepCompletedCommand
                => _cepCompletedCommand
                ??= new AsyncCommand(
                    execute: CepCompletedCommandExecute,
                    onException: CommandOnException);

        private int? alunoId;
        public int? AlunoId
        {
            get => alunoId;
            set
            {
                SetProperty(ref alunoId, value);
                CheckFormIsValid();
            }
        }

        private string nome;
        public string Nome
        {
            get => nome;
            set
            {
                SetProperty(ref nome, value);
                CheckFormIsValid();
            }
        }

        private DateTime? dataNascimento = DateTime.Now.AddYears(-17);
        public DateTime? DataNascimento
        {
            get => dataNascimento;
            set
            {
                SetProperty(ref dataNascimento, value);
                CheckFormIsValid();
            }
        }

        private string celular;
        public string Celular
        {
            get => celular;
            set
            {
                SetProperty(ref celular, value);
                CheckFormIsValid();
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, value);
                CheckFormIsValid();
            }
        }

        private string nomeMae;
        public string NomeMae
        {
            get => nomeMae;
            set
            {
                SetProperty(ref nomeMae, value);
                CheckFormIsValid();
            }
        }

        private string celularMae;
        public string CelularMae
        {
            get => celularMae;
            set
            {
                SetProperty(ref celularMae, value);
                CheckFormIsValid();
            }
        }

        private string nomePai;
        public string NomePai
        {
            get => nomePai;
            set
            {
                SetProperty(ref nomePai, value);
                CheckFormIsValid();
            }
        }

        private string celularPai;
        public string CelularPai
        {
            get => celularPai;
            set
            {
                SetProperty(ref celularPai, value);
                CheckFormIsValid();
            }
        }

        private string logradouro;
        public string Logradouro
        {
            get => logradouro;
            set
            {
                SetProperty(ref logradouro, value);
                CheckFormIsValid();
            }
        }

        private string cep;
        public string Cep
        {
            get => cep;
            set
            {
                SetProperty(ref cep, value);
                CheckFormIsValid();
            }
        }

        private string numero;
        public string Numero
        {
            get => numero;
            set
            {
                SetProperty(ref numero, value);
                CheckFormIsValid();
            }
        }

        private string bairro;
        public string Bairro
        {
            get => bairro;
            set
            {
                SetProperty(ref bairro, value);
                CheckFormIsValid();
            }
        }

        private string complemento;
        public string Complemento
        {
            get => complemento;
            set
            {
                SetProperty(ref complemento, value);
                CheckFormIsValid();
            }
        }

        private bool isValid;
        public bool IsValid
        {
            get => isValid;
            set => SetProperty(ref isValid, value);
        }

        private async Task SalvarCommandExecute()
        {
            try
            {
                if (IsBusy) return;

                //TODO validar
                CheckFormIsValid();
                if (IsValid)
                {
                    var response = await _alunoService.SalvarAsync(new Services.Requests.Aluno.AlterarAlunoRequest
                    {
                        NascidoEm = DataNascimento.Value,
                        Nome = Nome,
                        WhatsappIgualCelular = true,
                        AlunoId = AlunoId,
                        TurmaId = TurmaSelecionada.TurmaId,
                        Contatos = new List<NovoContatoRequest>
                        {
                            new NovoContatoRequest(Celular, Services.Requests.Aluno.TipoContatoRequest.Celular),
                            new NovoContatoRequest(Email, Services.Requests.Aluno.TipoContatoRequest.Email)
                        },
                        Enderecos = new List<NovoEnderecoRequest>
                        {
                            new NovoEnderecoRequest(Logradouro, Numero, cep: Cep, 1)//TODO Change bairro Id
                        }
                    });
                }
                else
                {
                    await DialogService.DisplayAlert("Oops", "Algum campo não foi preenchido incorretamente");
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                throw;
            }
        }
        private void CheckFormIsValid()
        {
            IsValid = string.IsNullOrWhiteSpace(Nome).Not()
                && DataNascimento is not null && DataNascimento < DateTime.Now
                && string.IsNullOrWhiteSpace(Logradouro).Not()
                && string.IsNullOrWhiteSpace(Numero).Not()
                && string.IsNullOrWhiteSpace(Bairro).Not()
                && string.IsNullOrWhiteSpace(NomeMae).Not()
                && string.IsNullOrWhiteSpace(CelularMae).Not()
                && string.IsNullOrWhiteSpace(Celular).Not();
        }

        private void SetTurmaSelecionada(string content)
        {
            if (string.IsNullOrEmpty(content).Not())
            {
                TurmaSelecionada = JsonSerializer.Deserialize<TurmaResponse>(content);
                DataNascimento = DateTime.Now.AddYears(-TurmaSelecionada.IdadeMaxima + 1);
            }
        }

        private async Task CepCompletedCommandExecute()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Cep).Not() && Cep.Length == 10)
                {
                    var endereco = await _cepService.ObterAsync(Cep);
                    if (endereco.IsSuccess)
                    {
                        Complemento = endereco.Data.Complemento;
                        Logradouro = endereco.Data.Logradouro;
                        Bairro = endereco.Data.Bairro;
                    }
                    else Debug.WriteLine("Was not possible to get cep information");
                }
                else Debug.WriteLine("CEP is not valid");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

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

                if (Turmas.Count == 1)
                {
                    TurmaSelecionada = Turmas[0];
                }
                else if (TurmaSelecionada is not null)
                {

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
    }
}
