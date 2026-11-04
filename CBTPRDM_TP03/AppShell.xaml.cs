/*
Dupla: André Luiz Nascimento de Andrade
       João do Valle Seixas Paula
*/
using CBTPRDM_TP03.Views;

namespace CBTPRDM_TP03;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Rota da página de resultados (acessada via GoToAsync a partir da HomePage)
        Routing.RegisterRoute(Routes.Result, typeof(ResultPage));
    }
}
