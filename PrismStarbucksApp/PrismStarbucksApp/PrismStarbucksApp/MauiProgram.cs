using Microsoft.Maui.Platform;

namespace PrismStarbucksApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UsePrism(PrismStartup.Configure)
            .ConfigureFonts(fonts =>
            {
                //fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                //fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                fonts.AddFont("ProximaNova-Regular.otf", "ProximaNovaRegular");
                fonts.AddFont("Raleway-Regular.ttf", "RalewayRegular");
                fonts.AddFont("Raleway-Medium.ttf", "RalewayMedium");
            });
        HandleEntryHandler();
        return builder.Build();
    }

    public static void HandleEntryHandler()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS || MACCATALYST
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
            handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
#endif
        });
    }
}

