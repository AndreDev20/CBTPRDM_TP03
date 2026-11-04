/*
Dupla: André Luiz Nascimento de Andrade
       João do Valle Seixas Paula
*/
using System.Collections.ObjectModel;
using System.Windows.Input;
using CBTPRDM_TP03.Models;

namespace CBTPRDM_TP03.ViewModels;

/// <summary>ViewModel da página de resultados: expõe o pacote recebido na navegação.</summary>
public class ResultViewModel : BaseViewModel, IQueryAttributable
{
    private PackageModel? _package;

    public ResultViewModel()
    {
        BackCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
    }

    public PackageModel? Package
    {
        get => _package;
        private set => SetProperty(ref _package, value);
    }

    /// <summary>Histórico do mais recente para o mais antigo.</summary>
    public ObservableCollection<TrackingEvent> History { get; } = new();

    public ICommand BackCommand { get; }

    // Chamado pelo Shell com os parâmetros enviados em GoToAsync
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue(nameof(PackageModel), out var value) && value is PackageModel package)
        {
            Package = package;

            History.Clear();
            foreach (var item in package.History.OrderByDescending(e => e.Date))
                History.Add(item);
        }
    }
}
