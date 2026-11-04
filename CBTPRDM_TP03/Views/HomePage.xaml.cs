/*
Dupla: André Luiz Nascimento de Andrade
       João do Valle Seixas Paula
*/
using CBTPRDM_TP03.ViewModels;

namespace CBTPRDM_TP03.Views;

public partial class HomePage : ContentPage
{
    // A ViewModel chega por injeção de dependência (registrada no MauiProgram)
    public HomePage(TrackingViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
