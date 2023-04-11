namespace SolarFree;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Comfortaa-Light.ttf", "ComfortaaLight");
				fonts.AddFont("Soft-Black.otf", "SoftBlack");
			});

		return builder.Build();
	}
}
