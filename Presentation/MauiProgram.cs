using Microsoft.AspNetCore.Components.WebView.Maui;
using Presentation.Data;
using Presentation.Services;
using Presentation.Services.Interfaces;

namespace Presentation
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
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddSingleton<IUserServices, UserServices>();
			builder.Services.AddSingleton<IShelterServices, ShelterServices>();
			builder.Services.AddSingleton<ICatServices, CatServices>();
			builder.Services.AddSingleton<IDogServices, DogServices>();

			return builder.Build();
        }
    }
}