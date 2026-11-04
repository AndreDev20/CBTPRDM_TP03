/*
Dupla: André Luiz Nascimento de Andrade
       João do Valle Seixas Paula
*/
using CBTPRDM_TP03.Services;
using CBTPRDM_TP03.ViewModels;
using CBTPRDM_TP03.Views;
using Microsoft.Extensions.Logging;

namespace CBTPRDM_TP03;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Serviço de dados (simulado). Para usar uma API real, basta trocar a implementação.
        builder.Services.AddSingleton<ITrackingService, MockTrackingService>();

        // ViewModels
        builder.Services.AddTransient<TrackingViewModel>();
        builder.Services.AddTransient<ResultViewModel>();

        // Views (recebem a ViewModel por injeção de dependência)
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<ResultPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
