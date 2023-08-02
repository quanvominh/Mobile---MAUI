using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Week2;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        //On<iOS>().SetUseSafeArea(false);
    }

    private void HambugerTapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }
}


