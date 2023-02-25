using DestinyLife.Auth0;
using Microsoft.Extensions.Logging;

namespace DestinyLife;

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

        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton(new Auth0Client(new()
        {
            Domain = "leeroya.auth0.com",
            ClientId = "ZejUMbk2YAIYE5gTStccPo6xCx33tUMt",
            Scope = "openid profile",
            RedirectUri = "myapp://callback"
        }));
        
		return builder.Build();
	}
}
