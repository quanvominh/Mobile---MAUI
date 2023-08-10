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
                .OnAppStart(navigationService => navigationService.CreateBuilder()
                    .AddNavigationPage()
                    .AddSegment<SplashPageViewModel>()
                    .Navigate());
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MainPage>()
                     .RegisterInstance(SemanticScreenReader.Default);
        containerRegistry.RegisterForNavigation<SplashPage>();
        containerRegistry.RegisterForNavigation<CustomTabBar>();
        containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
        containerRegistry.RegisterForNavigation<DetailsPage, DetailsPageViewModel>();

        containerRegistry.RegisterSingleton<ProductService>();
        containerRegistry.RegisterSingleton<IHttpRequest, HttpRequest>();
        containerRegistry.RegisterSingleton<IDatabaseConnection, DatabaseConnection>();
        containerRegistry.RegisterSingleton<ISqLiteService, SqLiteService>();
    }
}

