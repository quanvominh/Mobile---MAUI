using Week3.Views;
using Week3.ViewModels;

namespace Week3;

internal static class PrismStartup
{
    public static void Configure(PrismAppBuilder builder)
    {
        builder.RegisterTypes(RegisterTypes)
                .OnAppStart("NavigationPage/MainPage");
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<AppShell>()
                     .RegisterInstance(SemanticScreenReader.Default);
        containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>()
                     .RegisterInstance(SemanticScreenReader.Default);

        containerRegistry.RegisterForNavigation<BasicBindingPage>();
        containerRegistry.RegisterForNavigation<BindingModePage, BindingModePageViewModel>();
        containerRegistry.RegisterForNavigation<ValueConverterPage>();
        containerRegistry.RegisterForNavigation<StyleClassesPage, StyleClassesPageViewModel>();
        containerRegistry.RegisterForNavigation<AssignmentWeek2Page>();
    }
}

