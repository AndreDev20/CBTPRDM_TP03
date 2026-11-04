/*
Dupla: André Luiz Nascimento de Andrade
       João do Valle Seixas Paula
*/
using System.Windows.Input;
using CBTPRDM_TP03.Models;
using CBTPRDM_TP03.Services;

namespace CBTPRDM_TP03.ViewModels;

/// <summary>
/// ViewModel da página inicial: recebe o código digitado, busca o pacote
/// e navega para a página de resultados.
/// </summary>
public class TrackingViewModel : BaseViewModel
{
    private readonly ITrackingService _trackingService;
    private readonly Command _searchCommand;

    private string _trackingCode = string.Empty;
    private string _errorMessage = string.Empty;
    private bool _isBusy;

    public TrackingViewModel(ITrackingService trackingService)
    {
        _trackingService = trackingService;
        _searchCommand = new Command(async () => await SearchAsync(), () => !IsBusy);
    }

    public string TrackingCode
    {
        get => _trackingCode;
        set => SetProperty(ref _trackingCode, value);
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        private set
        {
            if (SetProperty(ref _errorMessage, value))
                OnPropertyChanged(nameof(HasError));
        }
    }

    public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

    public bool IsBusy
    {
        get => _isBusy;
        private set
        {
            if (SetProperty(ref _isBusy, value))
                _searchCommand.ChangeCanExecute();
        }
    }

    public ICommand SearchCommand => _searchCommand;

    private async Task SearchAsync()
    {
        ErrorMessage = string.Empty;

        var code = TrackingCode?.Trim().ToUpperInvariant() ?? string.Empty;
        if (code.Length == 0)
        {
            ErrorMessage = "Informe o código de rastreamento.";
            return;
        }

        try
        {
            IsBusy = true;

            PackageModel? package = await _trackingService.GetPackageAsync(code);
            if (package is null)
            {
                ErrorMessage = $"Nenhum pacote encontrado para o código {code}.";
                return;
            }

            // Navega para a página de resultados enviando o pacote encontrado
            await Shell.Current.GoToAsync(Routes.Result, new Dictionary<string, object>
            {
                [nameof(PackageModel)] = package
            });
        }
        finally
        {
            IsBusy = false;
        }
    }
}
