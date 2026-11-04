/*
Dupla: André Luiz Nascimento de Andrade
       João do Valle Seixas Paula
*/
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CBTPRDM_TP03.ViewModels;

/// <summary>Base com INotifyPropertyChanged para todas as ViewModels.</summary>
public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
