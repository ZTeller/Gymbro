using GymBro.View;

namespace GymBro;

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

        builder.Services.AddSingleton<GymBroViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton<GymBroBMIViewModel>();
        builder.Services.AddSingleton<BMI>();

        builder.Services.AddSingleton<GymBroCTViewModel>();
        builder.Services.AddSingleton<CalorieTracker>();

        builder.Services.AddSingleton<GymBroWLViewModel>();
        builder.Services.AddSingleton<WorkoutLogger>();

        builder.Services.AddSingleton<GymBroWPViewModel>();
        builder.Services.AddSingleton<WorkoutPlanner>();

        builder.Services.AddSingleton<GymBroMapViewModel>();
        builder.Services.AddSingleton<MapScreen>();
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);


        return builder.Build();
	}
}
