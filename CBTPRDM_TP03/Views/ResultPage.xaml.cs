/*
Dupla: André Luiz Nascimento de Andrade
       João do Valle Seixas Paula
*/
using CBTPRDM_TP03.ViewModels;

namespace CBTPRDM_TP03.Views;

public partial class ResultPage : ContentPage
{
    public ResultPage(ResultViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
