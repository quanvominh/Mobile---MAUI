using System;
using NavigationMode = Prism.Navigation.NavigationMode;

namespace Week3.ViewModels
{
    public class BasicBindingPageViewModel : INavigatedAware
    {
        public BasicBindingPageViewModel()
        {
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
            if (parameters.ContainsKey("name"))
            {
                var value = (string)parameters["name"];
            }
        }

        public virtual void OnNavigatedBackTo(INavigationParameters parameters)
        {

        }
    }
}

