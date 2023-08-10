using System;
using Prism.Navigation;
using PrismStarbucksApp.ViewModels.Commons;
using PrismStarbucksApp.Views;

namespace PrismStarbucksApp.ViewModels
{
    public class SplashPageViewModel : BaseViewModels
    {
        public SplashPageViewModel(INavigationService navigationService) : base(navigationService: navigationService)
        {
        }

        public override async void OnAppearing()
        {
            await Task.Delay(3000);
            await Navigation.CreateBuilder()
            .UseAbsoluteNavigation()
            .AddNavigationPage()
            .AddSegment<HomePage>()
            .NavigateAsync();
        }
    }
}

