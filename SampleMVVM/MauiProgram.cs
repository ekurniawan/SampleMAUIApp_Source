using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SampleMVVM.Services;
using SampleMVVM.ViewModel;

namespace SampleMVVM;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>().UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<MonkeyService>();
        builder.Services.AddSingleton<MonkeyViewModel>();
        builder.Services.AddTransient<MonkeyDetailsViewModel>();

        return builder.Build();
    }
}
