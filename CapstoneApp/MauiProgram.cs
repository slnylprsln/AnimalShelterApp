using CapstoneApp.Data;
using CapstoneApp.Services;
using CapstoneApp.Services.Interfaces;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace CapstoneApp
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
            builder.Services.AddSingleton<IDonationServices, DonationServices>();
            builder.Services.AddSingleton<IFollowServices, FollowServices>();



            return builder.Build();
		}
	}
}