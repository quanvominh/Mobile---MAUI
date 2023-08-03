using Week4.Interfaces;
using Week4.Services;
using Week4.Views;

namespace Week4;

internal static class PrismStartup
{
    public static void Configure(PrismAppBuilder builder)
    {
        builder.RegisterTypes(RegisterTypes)
                .OnAppStart("NavigationPage/MainPage");
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MainPage>()
                     .RegisterInstance(SemanticScreenReader.Default);

        containerRegistry.RegisterSingleton<IHttpRequest, HttpRequest>();
        containerRegistry.RegisterSingleton<IDatabaseConnection, DatabaseConnection>();
        containerRegistry.RegisterSingleton<ISqLiteService, SqLiteService>();
    }
}

