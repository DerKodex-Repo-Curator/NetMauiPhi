using Microsoft.Extensions.Logging;
using NetMauiPhi.Services;
using NetMauiPhi.ViewModels;
using NetMauiPhi.Views;

namespace NetMauiPhi
{
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IPhiService, PhiService>();

            builder.Services.AddScoped<Phi4ViewModel>()
                .AddScoped<Phi4MultimodalViewModel>()
                .AddScoped<PhiRagViewModel>();

            builder.Services.AddScoped<Phi4View>()
                .AddScoped<Phi4MultimodalView>()
                .AddScoped<PhiRagView>();

            return builder.Build();
        }
    }
}
