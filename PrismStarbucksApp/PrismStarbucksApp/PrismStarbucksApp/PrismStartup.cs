using PrismStarbucksApp.Interfaces;
using PrismStarbucksApp.Services;
using PrismStarbucksApp.ViewModels;
using PrismStarbucksApp.Views;

namespace PrismStarbucksApp;

internal static class PrismStartup
{
    public static void Configure(PrismAppBuilder builder)
    {
        builder.RegisterTypes(RegisterTypes)
                .OnAppStart($"NavigationPage/{nameof(HomePage)}");
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MainPage>()
                     .RegisterInstance(SemanticScreenReader.Default);
        containerRegistry.RegisterForNavigation<CustomTabBar>();
        containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
        containerRegistry.RegisterForNavigation<DetailsPage, DetailsPageViewModel>();

        containerRegistry.RegisterSingleton<ProductService>();
        containerRegistry.RegisterSingleton<IHttpRequest, HttpRequest>();
        containerRegistry.RegisterSingleton<IDatabaseConnection, DatabaseConnection>();
        containerRegistry.RegisterSingleton<ISqLiteService, SqLiteService>();
    }
}

