using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using PrismStarbucksApp.Interfaces;
using NavigationMode = Prism.Navigation.NavigationMode;

namespace PrismStarbucksApp.ViewModels.Commons
{
    public class BaseViewModels : BindableBase, INavigationAware, IInitialize, IPageLifecycleAware, IDestructible, INotifyPropertyChanged
    {
        #region Props

        public INavigationService Navigation { get; private set; }
        public IHttpRequest HttpRequest { get; private set; }
        public ISqLiteService SqLiteService { get; private set; }

        #endregion

        public BaseViewModels(INavigationService navigationService = null, IHttpRequest httpRequest = null, ISqLiteService sqLiteService = null)
        {
            if (navigationService != null) Navigation = navigationService;
            if (httpRequest != null) HttpRequest = httpRequest;
            if (sqLiteService != null) SqLiteService = sqLiteService;

            BackCommand = new DelegateCommand(async () => await BackExecute());
        }

        #region Lifecycle


        public virtual void Initialize(INavigationParameters parameters)
        {

        }


        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }

        public virtual void Destroy()
        {

        }

        #endregion

        #region Navigation

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
#if DEBUG
            Debug.WriteLine("Navigated from");
#endif
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
#if DEBUG
            Debug.WriteLine("Navigating to");
#endif
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
#if DEBUG
            Debug.WriteLine("Navigated to");
#endif 

            if (parameters != null)
            {
                var navMode = parameters.GetNavigationMode();
                switch (navMode)
                {
                    case NavigationMode.New: OnNavigatedNewTo(parameters); break;
                    case NavigationMode.Back: OnNavigatedBackTo(parameters); break;
                }
            }

        }

        public virtual void OnNavigatedNewTo(INavigationParameters parameters)
        {
#if DEBUG
            Debug.WriteLine("Navigate new to");
#endif
        }

        public virtual void OnNavigatedBackTo(INavigationParameters parameters)
        {
#if DEBUG
            Debug.WriteLine("Navigate back to");
#endif
        }

        #endregion

        #region BackCommand

        public ICommand BackCommand { get; }

        protected virtual async Task BackExecute()
        {
            await Navigation.GoBackAsync();
        }

        #endregion
    }
}

