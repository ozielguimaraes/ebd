using Ebd.CrossCutting.Enumerators;
using Ebd.Mobile.Constants;
using Ebd.Mobile.Extensions;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Requests.Aluno;
using Ebd.Mobile.Services.Requests.Contato;
using Ebd.Mobile.Services.Requests.Endereco;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Cep;
using Ebd.Mobile.Services.Responses.Turma;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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
        private readonly IAlunoService _alunoService;
        private readonly IBairroService _bairroService;
        private readonly ICepService _cepService;
        private readonly ITurmaService _turmaService;

        public NovoAlunoViewModel(ITurmaService turmaService, IAlunoService alunoService, IBairroService bairroService, ICepService cepService, IDiagnosticService diagnosticService, IDialogService dialogService, ILoggerService loggerService) : base(diagnosticService, dialogService, loggerService)
        {
            _turmaService = turmaService;
            Title = "Adicionar aluno";
            _alunoService = alunoService;
            _bairroService = bairroService;
            _cepService = cepService;
            Responsaveis = new ObservableCollection<PessoaResponsavelRequest>();
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
                TurmaAlterada(turmaSelecionadaAnteriormente);
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

        private ICommand _adicionarResponsavelCommand;
        public ICommand AdicionarResponsavelCommand
                => _adicionarResponsavelCommand
                ??= new AsyncCommand(
                    execute: AdicionarResponsavelCommandExecute,
                    canExecute: PermitirAdicionarResponsavel,
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

        private int? responsavelId;
        public int? ResponsavelId
        {
            get => responsavelId;
            set => SetProperty(ref responsavelId, value);
        }

        private int? pessoaResponsavelId;
        public int? PessoaResponsavelId
        {
            get => pessoaResponsavelId;
            set => SetProperty(ref pessoaResponsavelId, value);
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

        private string dataNascimento;
        public string DataNascimento
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
                SetProperty(ref email, value?.ToLower());
                CheckFormIsValid();
            }
        }

        public ObservableCollection<PessoaResponsavelRequest> Responsaveis { get; set; }

        private string nomeMae;
        public string NomeMae
        {
            get => nomeMae;
            set
            {
                SetProperty(ref nomeMae, value?.ToTitleCase());
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
                SetProperty(ref nomePai, value?.ToTitleCase());
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

        private int bairroId;
        public int BairroId
        {
            get => bairroId;
            set
            {
                SetProperty(ref bairroId, value);
                CheckFormIsValid();
            }
        }

        private string bairro;
        public string Bairro
        {
            get => bairro;
            set => SetProperty(ref bairro, value);
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
                    var enderecoAluno = new EnderecoRequest(Logradouro, Numero, cep: Cep, BairroId);

                    var alunoRequest = new AlterarAlunoRequest
                    {
                        NascidoEm = DataNascimento.ToDateTime(),
                        Nome = Nome.ToTitleCase(),
                        WhatsappIgualCelular = true,
                        AlunoId = AlunoId,
                        TurmaId = TurmaSelecionada.TurmaId,
                        Contatos = new List<ContatoRequest>
                        {
                            new ContatoRequest(Celular, TipoContato.Celular),
                            new ContatoRequest(Email, TipoContato.Email)
                        },
                        Enderecos = new List<EnderecoRequest> { enderecoAluno },
                        Responsaveis = ObterResponsaveis(enderecoAluno)
                    };
                    var response = await _alunoService.SalvarAsync(alunoRequest);
                    if (response.IsSuccess)
                    {
                        await DialogService.DisplayAlert("Heheeee", "Aluno adicionado com sucesso");
                    }
                    else
                    {
                        await DialogService.DisplayAlert("Oops", "Não foi possível adicionar o aluno");
                    }
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

        private List<PessoaResponsavelRequest> ObterResponsaveis(EnderecoRequest enderecoAluno)
        {
            var responsaveis = new List<PessoaResponsavelRequest>();
            var responsavelMae = new PessoaRequest(NomeMae.ToTitleCase(), new ContatoRequest(CelularMae, TipoContato.Celular))
            {
                Enderecos = new List<EnderecoRequest> { enderecoAluno }
            };
            responsaveis.Add(new PessoaResponsavelRequest(
                               pessoaResponsavelId: PessoaResponsavelId.OrZero(),
                               responsavelId: ResponsavelId.OrZero(),
                               responsavelMae,
                               alunoId: AlunoId.OrZero(),
                               tipoResponsavel: TipoResponsavel.Mae));

            if (NomePai is not null)
            {
                var responsavelPai = new PessoaRequest(NomePai.ToTitleCase(), new ContatoRequest(CelularPai, TipoContato.Celular))
                {
                    Enderecos = new List<EnderecoRequest> { enderecoAluno }
                };
                responsaveis.Add(new PessoaResponsavelRequest(
               pessoaResponsavelId: PessoaResponsavelId.OrZero(),
               responsavelId: ResponsavelId.OrZero(),
               responsavelPai,
               alunoId: AlunoId.OrZero(),
               tipoResponsavel: TipoResponsavel.Pai));
            }

            return responsaveis;
        }

        private void CheckFormIsValid()
        {
            IsValid = string.IsNullOrWhiteSpace(Nome).Not()
                && DataNascimento is not null
                && string.IsNullOrWhiteSpace(Logradouro).Not()
                && string.IsNullOrWhiteSpace(Numero).Not()
                && string.IsNullOrWhiteSpace(Bairro).Not()
                && string.IsNullOrWhiteSpace(NomeMae).Not()
                && string.IsNullOrWhiteSpace(CelularMae).Not() && CelularMae.Length == 15
                && string.IsNullOrWhiteSpace(Celular).Not() && Celular.Length == 15
                && (CelularPai is null || CelularPai.Length == 15);
        }

        private void SetTurmaSelecionada(string content)
        {
            if (string.IsNullOrWhiteSpace(content).Not())
            {
                TurmaSelecionada = JsonSerializer.Deserialize<TurmaResponse>(content);
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
                        await TentarBuscarInformacaoBairro(endereco);
                    }
                    else Debug.WriteLine("Was not possible to get cep information");
                }
                else Debug.WriteLine("CEP is not valid");
            }
            catch (Exception ex)
            {
                ex.LogFullException(nameof(CepCompletedCommandExecute));
            }
        }

        private bool PermitirAdicionarResponsavel(object args) => IsValid && IsNotBusy;

        private async Task AdicionarResponsavelCommandExecute()
        {
            try
            {
                await Shell.Current.GoToAsync(PageConstant.Aluno.ResponsavelAluno.Adicionar);
            }
            catch (Exception ex)
            {
                ex.LogFullException(nameof(AdicionarResponsavelCommandExecute));
            }
        }

        private async Task TentarBuscarInformacaoBairro(BaseResponse<CepResponse> endereco)
        {
            var respostaPesquisaBairro = await _bairroService.PesquisarAsync(endereco.Data.Bairro); //TODO Buscar banco local??
            if (respostaPesquisaBairro.IsSuccess)
            {
                if (respostaPesquisaBairro.Data.FirstOrDefault() is not null)
                {
                    var bairro = respostaPesquisaBairro.Data.First();
                    BairroId = bairro.BairroId;
                    Bairro = bairro.Nome;
                }
            }
        }

        public override async Task Appearing(object args)
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
                    TurmaSelecionada = Turmas[0];
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

        private void TurmaAlterada(TurmaResponse turmaSelecionadaAnteriormente)
        {
            if (TurmaSelecionada is not null && TurmaSelecionada.Equals(turmaSelecionadaAnteriormente).Not())
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {

                });
            }
        }
    }
}
