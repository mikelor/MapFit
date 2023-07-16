namespace MapFit;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseMauiMaps()
			.UseMauiCommunityToolkitMarkup()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<AppShell>();

		builder.Services.AddSingleton<App>();

		builder.Services.AddTransient<MainPage, MainViewModel>();

		builder.Services.AddTransient<GamePage, GameViewModel>();

		builder.Services.AddTransient<DrawingPage, DrawingViewModel>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<ListDetailDetailViewModel>();
		builder.Services.AddTransient<ListDetailDetailPage>();

		builder.Services.AddTransient<ListDetailPage, ListDetailViewModel>();

		builder.Services.AddTransient<MapPage, MapViewModel>();

		return builder.Build();
	}
}
