using System.Collections.ObjectModel;
using System.Windows.Input;
using Week4.Interfaces;
using Week4.Models;
using Week4.Services;

namespace Week4.ViewModels;

public class MainPageViewModel : BindableBase
{
    private ISemanticScreenReader _screenReader { get; }
    public MainPageViewModel(ISemanticScreenReader screenReader)
    {
        _screenReader = screenReader;
    }

    private INavigationService _navigationService { get; }
    private IHttpRequest _httpRequest { get; }
    private ISqLiteService _sqLiteService { get; }

    private ObservableCollection<Cat> _cats = new ObservableCollection<Cat>();
    public ObservableCollection<Cat> Cats
    {
        get => _cats;
        set => SetProperty(ref _cats, value);
    }

    private bool _isLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value);
    }
    private string _text;
    public string Text
    {
        get => _text;
        set => SetProperty(ref _text, value);
    }

    public MainPageViewModel(HttpRequest httpRequest, SqLiteService sqLiteService, ISemanticScreenReader screenReader)
    {
        _screenReader = screenReader;
        _httpRequest = httpRequest;
        _sqLiteService = sqLiteService;

        GetDataCommand = new Command<string>(OnGetDataCommandExecuted);
        SaveAllDataCommand = new Command(OnSaveAllDataCommandExecuted);
        LoadAllDataCommand = new Command(OnLoadAllDataCommandExecuted);
        ShowBlankCommand = new Command(OnShowBlankCommandExecuted);
        DeleteAllCommand = new Command(OnDeleteAllCommandExecuted);
    }

    public ICommand GetDataCommand { get; }

    private async void OnGetDataCommandExecuted(string desPage)
    {
        IsLoading = true;
        Text = "Loading...";
        var res = await _httpRequest.GetTaskAsync<ObservableCollection<Cat>>("https://cat-fact.herokuapp.com/facts/random?animal_type=cat&amount=3");
        Cats = new ObservableCollection<Cat>(res);
        Text = "";
        IsLoading = false;
    }

    public ICommand SaveAllDataCommand { get; }

    private void OnSaveAllDataCommandExecuted()
    {
        IsLoading = true;
        Text = "Saving...";
        var res = _sqLiteService.InsertAll(Cats);
        Text = "";
        IsLoading = false;
    }

    public ICommand LoadAllDataCommand { get; }

    private void OnLoadAllDataCommandExecuted()
    {
        IsLoading = true;
        Text = "Loading local DB...";
        var res = _sqLiteService.GetList<Cat>(c => c.Text != null);
        Cats = new ObservableCollection<Cat>(res);
        Text = "";
        IsLoading = false;
    }

    public ICommand ShowBlankCommand { get; }
    private void OnShowBlankCommandExecuted()
    {
        IsLoading = true;
        Text = "Reseting...";
        Cats = new ObservableCollection<Cat>();
        Text = "";
        IsLoading = false;
    }

    public ICommand DeleteAllCommand { get; }
    private void OnDeleteAllCommandExecuted()
    {
        IsLoading = true;
        Text = "Deleting...";
        var res = _sqLiteService.DeleteAll<Cat>();
        Cats = new ObservableCollection<Cat>();
        Text = "";
        IsLoading = false;
    }
}

