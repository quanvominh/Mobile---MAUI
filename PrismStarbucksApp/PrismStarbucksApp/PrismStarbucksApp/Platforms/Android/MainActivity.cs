using Android.App;
using Android.Content.PM;
using Android.OS;

namespace PrismStarbucksApp;

[Activity(Theme = "@style/CustomTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
}

