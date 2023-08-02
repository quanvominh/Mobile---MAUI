using System.Windows.Input;
using Prism.Navigation;
using Week3.Views;
using NavigationMode = Prism.Navigation.NavigationMode;

namespace Week3.ViewModels;

public class MainPageViewModel : BindableBase, INavigatedAware
{
    private ISemanticScreenReader _screenReader { get; }
    private INavigationService _navigationService { get; }
    private int _count;

    public MainPageViewModel(ISemanticScreenReader screenReader, INavigationService navigationService)
    {
        _screenReader = screenReader;
        _navigationService = navigationService;
        CountCommand = new DelegateCommand(OnCountCommandExecuted);
        DetailCommand = new Command<Type>(OnDetailCommandExecuted);
    }

    public string Title => "Main Page";

    private string _text = "Click me";
    public string Text
    {
        get => _text;
        set => SetProperty(ref _text, value);
    }

    public DelegateCommand CountCommand { get; }

    private void OnCountCommandExecuted()
    {
        _count++;
        if (_count == 1)
            Text = "Clicked 1 time";
        else if (_count > 1)
            Text = $"Clicked {_count} times";

        _screenReader.Announce(Text);
    }

    public ICommand DetailCommand { get; }

    private async void OnDetailCommandExecuted(Type desPage)
    {
        //await _navigationService.CreateBuilder()
        //    .AddNavigationSegment($"/{desPage.Name}")
        //    .NavigateAsync();
        var param = new NavigationParameters
        {
                { "name", ".NET MAUI" }
        };
        await _navigationService.NavigateAsync(desPage.Name, param);
    }

    public void OnNavigatedFrom(INavigationParameters parameters)
    {
        //throw new NotImplementedException();
    }

    public void OnNavigatedTo(INavigationParameters parameters)
    {
        if (parameters != null)
        {
            var navMode = parameters.GetNavigationMode();
            switch (navMode)
            {
                case NavigationMode.New:
                    OnNavigatedNewTo(parameters);
                    break;
                case NavigationMode.Back:
                    OnNavigatedBackTo(parameters);
                    break;
            }
        }
    }


    public virtual void OnNavigatedNewTo(INavigationParameters parameters)
    {

    }

    public virtual void OnNavigatedBackTo(INavigationParameters parameters)
    {

    }
}

